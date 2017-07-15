using CDD.Core.Expressions;

namespace CDD.Core.Constraints
{
    public class OutputConstraint : Constraint
    {
        public Expression Expression { get; }

        public OutputConstraint(Expression expression)
            => Expression = expression;
    }
}