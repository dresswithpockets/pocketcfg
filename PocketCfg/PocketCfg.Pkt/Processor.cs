using System.IO;
using Antlr4.Runtime;
using Antlr4.Runtime.Tree;

namespace PocketCfg.Pkt
{
    public class Processor
    {
        private readonly PktParser.StatementListContext _context;
        private readonly TextWriter _writer;

        public Processor(PktParser.StatementListContext context, TextWriter writer)
        {
            _context = context;
            _writer = writer;
        }

        public void Process()
        {
            foreach (var statement in _context.statement())
            {
                Process(statement);
                _writer.Write("\n");
            }
        }

        public void Process(PktParser.StatementContext context)
        {
            var values = context.value();
            for (var i = 0; i < values.Length; i++)
            {
                var value = values[i];
                Process(value);
                if (i < values.Length - 1) _writer.Write(" ");
            }
        }

        public void Process(PktParser.ValueContext context)
        {
            if (context.IDENT() != null) _writer.Write(context.IDENT().GetText());
            if (context.STRING_LIT() != null) _writer.Write(context.STRING_LIT().GetText());
            if (context.NUMBER() != null) _writer.Write(context.NUMBER().GetText());
        }

        public static Processor FromInput(string input, TextWriter writer)
        {
            var stream = CharStreams.fromString(input);
            var lexer = new PktLexer(stream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new PktParser(tokens) {BuildParseTree = true};
            return new Processor(parser.statementList(), writer);
        }
        
        public static Processor FromFile(string file, TextWriter writer)
        {
            return FromInput(File.ReadAllText(file), writer);
        }
    }
}