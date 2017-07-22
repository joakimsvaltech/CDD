using System;
using CDD.Core.Tokens;

namespace CDD.Core
{
    internal class TokenGenerator
    {
        private readonly string _pattern;
        private readonly Func<string, Token> _generator;

        public TokenGenerator(string pattern, Func<string, Token> generator)
        {
            _pattern = pattern;
            _generator = generator;
        }

        public bool TryGenerate(string input, out Token token, out string remains)
        {
            var offset = input.Length - _pattern.Length;
            if (offset < 0 || input.Substring(offset) != _pattern)
            {
                token = null;
                remains = input;
                return false;
            }
            remains = input.Substring(0, offset);
            token = _generator(input.Substring(offset));
            return true;
        }
    }
}