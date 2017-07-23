using System;

namespace CDD.Core.Temporal
{
    public class Constant<TValue> : Expression, IEquatable<Constant<TValue>>
    {
        public TValue Value { get; }

        public Constant(TValue value)
            => Value = value;

        public bool Equals(Constant<TValue> other) => other != null && other.Value.Equals(Value);

        public override bool Equals(object obj) => Equals(obj as Constant<TValue>);

        public override int GetHashCode() => Value.GetHashCode();
    }
}