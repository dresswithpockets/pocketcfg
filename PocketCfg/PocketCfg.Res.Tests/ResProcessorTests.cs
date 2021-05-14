using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace PocketCfg.Res.Tests
{
    public class ResProcessorTests
    {
        [Fact]
        public void ParsesBasicObjectWithEmptyBody()
        {
            var input = @"
""Default""
{
}
";

            var processor = ResProcessor.FromInput(input);
            var output = processor.Process().Objects.ToList();
            Assert.Single(output);
            
            var obj = output[0];
            Assert.NotNull(obj);
            Assert.Equal("Default", obj.Name);
            Assert.False(obj.IsValue);
            Assert.Empty(obj.Properties);
            Assert.Empty(obj.Flags);
        }

        [Fact]
        public void ParsesListOfObjects()
        {
            var input = @"
""Default1""
{
}


""Default2""
{
}
";
            var processor = ResProcessor.FromInput(input);
            var output = processor.Process().Objects.ToList();
            Assert.Equal(2, output.Count);

            for (var i = 0; i < output.Count; i++)
            {
                var obj = output[i];
                Assert.NotNull(obj);
                Assert.Equal($"Default{i+1}", obj.Name);
                Assert.False(obj.IsValue);
                Assert.Empty(obj.Properties);
                Assert.Empty(obj.Flags);
            }
        }

        [Fact]
        public void ParsesObjectWithPlatformFlag()
        {
            var input = @"
""Default"" [$WIN32]
{
}
";

            var processor = ResProcessor.FromInput(input);
            var output = processor.Process().Objects.ToList();
            Assert.Single(output);
            
            var obj = output[0];
            Assert.NotNull(obj);
            Assert.Equal("Default", obj.Name);
            Assert.False(obj.IsValue);
            Assert.Empty(obj.Properties);
            Assert.Contains("WIN32", obj.Flags as IReadOnlyDictionary<string, bool>);
            Assert.True(obj.Win32);
        }

        [Fact]
        public void ParsesObjectWithChildObject()
        {
            var input = @"
""Default""
{
    ""Child""
    {
    }
}
";

            var processor = ResProcessor.FromInput(input);
            var output = processor.Process().Objects.ToList();
            Assert.Single(output);
            
            var obj = output[0];
            Assert.NotNull(obj);
            Assert.Equal("Default", obj.Name);
            Assert.False(obj.IsValue);
            Assert.Empty(obj.Flags);
            Assert.Single(obj.Properties);

            var child = obj.Properties[0];
            Assert.NotNull(child);
            Assert.Equal("Child", child.Name);
            Assert.False(child.IsValue);
            Assert.Empty(child.Properties);
            Assert.Empty(child.Flags);
        }

        [Fact]
        public void ParsesObjectWithCommentIgnored()
        {
            var input = @"
// funny test :3

""Default""
{
}
";

            var processor = ResProcessor.FromInput(input);
            var output = processor.Process().Objects.ToList();
            Assert.Single(output);
            
            var obj = output[0];
            Assert.NotNull(obj);
            Assert.Equal("Default", obj.Name);
            Assert.False(obj.IsValue);
            Assert.Empty(obj.Properties);
            Assert.Empty(obj.Flags);
        }

        [Fact]
        public void ParsesObjectWithInlineComment()
        {
            var input = @"
""Default"" // funny test :3
{
}
";

            var processor = ResProcessor.FromInput(input);
            var output = processor.Process().Objects.ToList();
            Assert.Single(output);
            
            var obj = output[0];
            Assert.NotNull(obj);
            Assert.Equal("Default", obj.Name);
            Assert.False(obj.IsValue);
            Assert.Empty(obj.Properties);
            Assert.Empty(obj.Flags);
        }
    }
}