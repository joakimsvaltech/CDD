using System;
using CDD.Core.Spec;
using CDD.Perpetual.Tokens;

namespace CDD.Perpetual
{
    public static class Generator
    {
        public static Expression Compile(TreeNode tokenTree)
            => Generate(tokenTree).Resolve();

        private static Expression Generate(TreeNode tokenTree)
        {
            switch (tokenTree.Content)
            {
                case LeftParenthesis parenthesis: return Compile(tokenTree.Right);
                case Output output: return new Return(Compile(tokenTree.Right));
                case Add add: return new Addition(Compile(tokenTree.Left), Compile(tokenTree.Right));
                case Multiply multiply: return new Multiplication(Compile(tokenTree.Left), Compile(tokenTree.Right));
                case Literal literal:
                    return Constant.TryParse(literal.Value, out Constant constant)
                        ? constant
                        : new Constant<string>(literal.Value);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}