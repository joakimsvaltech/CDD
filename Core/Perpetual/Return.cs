namespace CDD.Core.Spec
{
    public class Return : Expression
    {
        public Return(Expression statement)
            => Statement = statement;

        public Expression Statement { get; }
    }
}