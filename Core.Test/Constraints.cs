using CDD.Core.Constraints;
using CDD.Core.Expressions;
using NUnit.Framework;

namespace CDD.Core.Test
{
    [TestFixture]
    public class Constraints
    {
        [TestCase(":< 0", 0)]
        [TestCase(":<  0", 0)]
        [TestCase(":< 1", 1)]
        public void CanParseIntConstantOutputConstraint(string representation, int expectedValue)
        {
            var constant = GetOutputConstantValue<int>(representation);
            Assert.That(constant.Value, Is.EqualTo(expectedValue));
        }

        [TestCase(":< 0.5", 0.5)]
        public void CanParseDecimalConstantOutputConstraint(string representation, decimal expectedValue)
        {
            var constant = GetOutputConstantValue<decimal>(representation);
            Assert.That(constant.Value, Is.EqualTo(expectedValue));
        }

        [TestCase(":< Hej", "Hej")]
        [TestCase(":< Hej hopp", "Hej hopp")]
        [TestCase(":< Hej  hopp", "Hej  hopp")]
        public void CanParseStringConstantOutputConstraint(string representation, string expectedValue)
        {
            var constant = GetOutputConstantValue<string>(representation);
            Assert.That(constant.Value, Is.EqualTo(expectedValue));
        }

        [TestCase(":< 1 + 1", 2)]
        [TestCase(":< 1+1", 2)]
        [TestCase(":<  1  +  1", 2)]
        [TestCase(":< 1+2+3", 6)]
        [TestCase(":< 1*1", 1)]
        [TestCase(":< 2*3+4", 10)]
        [TestCase(":< 2+3*4", 14)]
        public void CanParseAlgebraicConstantOutputConstraint(string representation, int expectedValue)
        {
            var constant = GetOutputConstantValue<int>(representation);
            Assert.That(constant.Value, Is.EqualTo(expectedValue));
        }

        private static Constant<TValue> GetOutputConstantValue<TValue>(string representation)
        {
            var constraint = Constraint.Parse(representation);
            Assert.That(constraint, Is.TypeOf<OutputConstraint>());
            var outputConstraint = (OutputConstraint)constraint;
            Assert.That(outputConstraint.Expression, Is.TypeOf<Constant<TValue>>());
            return (Constant<TValue>)outputConstraint.Expression;
        }
    }
}
