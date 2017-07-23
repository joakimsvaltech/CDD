using System.Collections.Generic;
using System.Linq;
using CDD.Perpetual.Tokens;

namespace CDD.Perpetual
{
    public class Tokenizer
    {
        private readonly string _representation;
        private readonly Stack<TreeNode> _currentRoot = new Stack<TreeNode>();

        public static TreeNode Parse(string representation)
            => new Tokenizer(representation).Parse();

        private Tokenizer(string representation)
            => _representation = representation;

        private TreeNode Parse()
        {
            var tokens = GetTokens(_representation);
            return BuildTree(tokens.ToList());
        }

        private IEnumerable<Token> GetTokens(string representation)
        {
            var current = "";
            foreach (var c in representation)
            {
                current += c;
                if (!TokenGenerators.TryGetValue(c, out TokenGenerator generator)) continue;
                if (!generator.TryGenerate(current.Trim(), out Token token, out string remains)) continue;
                if (remains.Any())
                    yield return new Literal(remains);
                yield return token;
                current = "";
            }
            if (current.Any())
                yield return new Literal(current);
        }

        private TreeNode BuildTree(List<Token> tokens)
        {
            var root = new TreeNode(null);
            _currentRoot.Push(root);
            tokens.ForEach(token =>
            {
                if (token is RightParenthesis)
                    _currentRoot.Pop();
                else
                {
                    var newNode = AddDescendant(_currentRoot.Peek(), token);
                    if (token is LeftParenthesis)
                        _currentRoot.Push(newNode);
                }
            });
            return root.Right;
        }

        private TreeNode AddDescendant(TreeNode node, Token token)
            => node.Right == null || token.Precedence > node.Right.Content.Precedence
            ? node.Right = new TreeNode(token, node.Right)
            : AddDescendant(node.Right, token);

        private static readonly Dictionary<char, TokenGenerator> TokenGenerators
            = new Dictionary<char, TokenGenerator>
            {
                { '(', new TokenGenerator("(", value => new LeftParenthesis())},
                { ')', new TokenGenerator(")", value => new RightParenthesis())},
                { '+', new TokenGenerator("+", value => new Add())},
                { '*', new TokenGenerator("*", value => new Multiply())},
                { '<', new TokenGenerator(":<", value => new Output())}
            };
    }
}