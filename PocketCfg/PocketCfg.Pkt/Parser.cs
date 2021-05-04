using System.Collections.Generic;

namespace PocketCfg.Pkt
{
    public class Parser
    {
        private readonly IEnumerable<Token> _tokens;

        public Parser(IEnumerable<Token> tokens) => _tokens = tokens;
        
        
    }
}