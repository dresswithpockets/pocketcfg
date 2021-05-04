using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text.RegularExpressions;

namespace PocketCfg.Pkt
{
    public class Lexer
    {
        private readonly string _input;

        public Lexer(string input)
        {
            _input = input;
        }

        public IEnumerable<Token> Tokenize()
        {
            var index = 0;
            var col = 1;
            var row = 0;
            char? Peek(int n = 0) => _input.Length < (index + n) ? _input[index + n] : null;

            Token Eat(TokenType type, int len)
            {
                var oldIndex = index;
                col += len;
                index += len;
                return new Token(type, row, col, _input[oldIndex..len].ToString());
            }

            while (true)
            {
                var current = Peek();
                if (current == '\r')
                {
                    index++;
                    current = Peek();
                }
                if (current == '\n')
                {
                    col = 1;
                    row++;
                    index++;
                    current = Peek();
                }
                if (current == '#') yield return Eat(TokenType.Directive, 1);
                else if (current == '@') yield return Eat(TokenType.Alias, 1);
                else if (current is '"' or '\'') yield return Eat(TokenType.Quote, 1);
                else if (current == '/' && Peek(1) == '/')
                {
                    // token is comment, skip to next line
                    index += 2;
                    while (true)
                    {
                        if (Peek() == '\n')
                        {
                            if (Peek(1) == '\r') index++;
                            index++;
                            row++;
                            col = 1;
                            break;
                        }
                    }
                }
                else if (current.HasValue && char.IsLetterOrDigit(current.Value))
                {
                    // token is value
                    var currentToken = "";
                    while (current.HasValue && char.IsLetterOrDigit(current.Value))
                    {
                        currentToken += current;
                        index++;
                        col++;
                        current = Peek();
                    }

                    yield return new Token(TokenType.Value, row, col, currentToken);
                }
                if (index == _input.Length) break;
            }
        }
    }

    public record Token(TokenType Type, int Row, int Column, string Value);

    public enum TokenType
    {
        Directive,
        Alias,
        Value,
        Quote,
    }
}