using NUnit.Framework;

namespace CDD.Core.Test
{
    using Perpetual;

    [TestFixture]
    public class Generators
    {
        [Test]
        public void YieldNoExpressions_GivenNoConstraint()
        {
            var expression = new CDD.Temporal.Generator().Generate(null);
            Assert.That(expression, Is.Null);
        }

        [TestCase(1)]
        [TestCase(23)]
        public void YieldIntConstant_GivenIntConstantOutputConstraint(int value)
        {
            YieldConstant_GivenConstantOutputConstraint(value);
        }

        [TestCase("A")]
        [TestCase("abc")]
        public void YieldIntConstant_GivenIntConstantOutputConstraint(string value)
        {
            YieldConstant_GivenConstantOutputConstraint(value);
        }

        private static void YieldConstant_GivenConstantOutputConstraint<TValue>(TValue value)
        {
            var constraint = new OutputConstraint { Expression = new Constant<TValue>(value) };
            var expression = new CDD.Temporal.Generator().Generate(constraint);
            var returns = expression as Temporal.Return;
            Assert.That(returns, Is.Not.Null);
            Assert.That(returns.Statement, Is.EqualTo(new Temporal.Constant<TValue>(value)));
        }
    }
}
