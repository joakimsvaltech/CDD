using System.Globalization;

namespace CDD.Core.Expressions
{
    public class Constant : Expression
    {
        public static bool TryParse(string outputRepresentation, out Constant expression)
        {
            expression = int.TryParse(outputRepresentation, out int intVal)
                ? new Constant<int>(intVal)
                : decimal.TryParse(outputRepresentation, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal decVal)
                    ? new Constant<decimal>(decVal)
                    : (Constant)null;
            return expression != null;
        }
    }

    public class Constant<TValue> : Constant
    {
        public TValue Value { get; }

        public Constant(TValue value)
            => Value = value;
    }
}