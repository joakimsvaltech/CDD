using System;
using CDD.Core.Constraints;
using CDD.Core.Tokens;

namespace CDD.Core.Expressions
{
    public class Expression
    {
        public static Expression Translate(TreeNode tokenTree)
        {
            switch (tokenTree.Content)
            {
                case Output output: return new Return(Translate(tokenTree.Right));
                case Add add: return new Addition(Translate(tokenTree.Left), Translate(tokenTree.Right)).Resolve();
                case Multiply multiply: return new Multiplication(Translate(tokenTree.Left), Translate(tokenTree.Right)).Resolve();
                case Literal literal:
                    return Constant.TryParse(literal.Value, out Constant constant)
                        ? constant
                        : new Constant<string>(literal.Value);
                default:
                    throw new NotImplementedException();
            }
        }

        public virtual Expression Resolve() => this;
    }
}