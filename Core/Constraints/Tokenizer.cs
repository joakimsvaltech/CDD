using System.Collections.Generic;
using System.Linq;
using CDD.Core.Tokens;

namespace CDD.Core.Constraints
{
    public static class Tokenizer
    {
        public static TreeNode Parse(string representation)
        {
            var tokens = Tokenizer.GetTokens(representation);
            return BuildTree(tokens.ToList());
        }

        private static IEnumerable<Token> GetTokens(string representation)
        {
            var current = "";
            foreach (var c in representation)
            {
                current += c;
                if (!TokenGenerators.TryGetValue(c, out TokenGenerator generator)) continue;
                if (!generator.TryGenerate(current, out Token token, out string remains)) continue;
                if (remains.Any())
                    yield return new Literal(remains);
                yield return token;
                current = "";
            }
            if (current.Any())
                yield return new Literal(current);
        }

        private static TreeNode BuildTree(List<Token> tokens)
        {
            var root = new TreeNode(null);
            tokens.ForEach(root.AddDescendant);
            return root.Right;
        }

        private static readonly Dictionary<char, TokenGenerator> TokenGenerators
            = new Dictionary<char, TokenGenerator>
            {
                { '+', new TokenGenerator("+", value => new Add())},
                { '*', new TokenGenerator("*", value => new Multiply())},
                { '<', new TokenGenerator(":<", value => new Output())}
            };
    }
}