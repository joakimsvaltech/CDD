namespace CDD.Core.Perpetual
{
    public class OutputConstraint : Constraint
    {
        public Expression Expression { get; set; }
        public override bool Apply(Temporal.Expression expression)
        {
            var returnExpression = expression as Temporal.Return;
            return returnExpression != null && Expression.Accept(returnExpression.Statement);
        }
    }
}