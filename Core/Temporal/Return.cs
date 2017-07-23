namespace CDD.Core.Temporal
{
    public class Return : Expression
    {
        public Return(Expression statement)
            => Statement = statement;

        public Expression Statement { get; }
    }
}