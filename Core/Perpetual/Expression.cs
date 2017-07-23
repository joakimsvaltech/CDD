namespace CDD.Core.Perpetual
{
    public abstract class Expression
    {
        public virtual Expression Resolve() => this;

        public abstract bool Accept(Temporal.Expression expression);
    }
}