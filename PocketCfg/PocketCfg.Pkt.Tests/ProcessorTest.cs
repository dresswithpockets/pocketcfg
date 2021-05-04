using System;
using System.IO;
using Xunit;

namespace PocketCfg.Pkt.Tests
{
    public class ProcessorTest
    {
        [Fact]
        public void TestBasicStatementCopiesVerbatim()
        {
            var input = @"
this is ""a test"" with a number 0.9 'and a number 1.1'
";
            var expected = "this is \"a test\" with a number 0.9 'and a number 1.1'\n";
            using var stringWriter = new StringWriter();
            var processor = Processor.FromInput(input, stringWriter);
            processor.Process();

            var output = stringWriter.ToString();
            Assert.Equal(expected, output);
        }
    }
}