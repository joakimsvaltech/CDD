namespace CDD.Core.Perpetual
{
    public abstract class Constraint
    {
        public string Representation { get; set; }

        public override string ToString()
            => Representation;

        public abstract bool Apply(Temporal.Expression expression);
    }
}