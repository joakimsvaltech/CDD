namespace CDD.Core.Expressions
{
    public class Constant<TValue> : Expression
    {
        private TValue Value { get; }

        public Constant(TValue value)
            => Value = value;
    }
}