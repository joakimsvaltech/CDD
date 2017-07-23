using CDD.Core.Temporal;

namespace CDD.Temporal.Transformations
{
    public class AddReturnValue<TValue> : Transform
    {
        private readonly TValue _value;

        public AddReturnValue(TValue value)
            => _value = value;

        public override Expression Apply()
            => new Return(new Constant<TValue>(_value));
    }
}
