using System.Linq;
using NUnit.Framework;

namespace CDD.Core.Test
{
    using Core.Constraints;
    using Expressions;

    [TestFixture]
    public class Generators
    {
        [Test]
        public void YieldNoExpressions_GivenNoConstraint() 
        {
            var expressions = Generator.Generate();
            Assert.That(expressions, Is.Empty);
        }

        [TestCase(1)]
        [TestCase(23)]
        public void YieldIntConstant_GivenIntConstantOutputConstraint(int value)
        {
            YieldConstant_GivenConstantOutputConstraint(new Constant<int>(value));
        }

        [TestCase("A")]
        [TestCase("abc")]
        public void YieldIntConstant_GivenIntConstantOutputConstraint(string value)
        {
            YieldConstant_GivenConstantOutputConstraint(new Constant<string>(value));
        }

        private static void YieldConstant_GivenConstantOutputConstraint(Expression output)
        {
            var constraint = new OutputConstraint { Expression = output };
            var expression = Generator.Generate(constraint).Single();
            Assert.That(expression, Is.EqualTo(output));
        }
    }
}