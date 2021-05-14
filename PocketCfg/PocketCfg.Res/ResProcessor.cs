using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using Antlr4.Runtime;

namespace PocketCfg.Res
{
    public class ResProcessor
    {
        private readonly ResParser.TranslationUnitContext _translationUnit;
    
        public ResProcessor(ResParser.TranslationUnitContext context)
        {
            _translationUnit = context;
        }

        public ResUnit Process() => new ResUnit(_translationUnit.DIRECTIVE().Select(d => d.GetText()),
            _translationUnit.@object().Select(Process));

        public ResObject Process(ResParser.ObjectContext context)
        {
            var name = GetValue(context.name());
            var resObject = new ResObject(name);

            if (context.flagSpecifier() is {} flagSpec)
            {
                var val = flagSpec.EXCL() == null;
                var flag = flagSpec.FLAG().GetText().Substring(1);
                resObject.Flags.Add(flag, val);
            }

            Process(context.objectBody(), resObject);
                
            return resObject;
        }

        public void Process(ResParser.ObjectBodyContext context, ResObject resObject)
        {
            if (context.STRING_LITERAL() != null)
            {
                var str = context.STRING_LITERAL().GetText();
                resObject.Value = str.Substring(1, str.Length - 2);
            }
            else resObject.Properties.AddRange(context.objectList().@object().Select(Process));
        }

        public string GetValue(ResParser.NameContext context)
        {
            if (context.IDENT() != null) return context.GetText();
            var str = context.STRING_LITERAL().GetText();
            return str.Substring(1, str.Length - 2);
        }

        public static ResProcessor FromInput(string input)
        {
            var stream = CharStreams.fromString(input);
            
            var lexer = new ResLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new ResParser(tokens) {BuildParseTree = true};
            return new ResProcessor(parser.translationUnit());
        }
        
        public static ResProcessor FromFile(string file) => FromInput(File.ReadAllText(file));
    }
}