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
            var constant = new Constant<int>(value);
            var constraint = new OutputConstraint(constant);
            var expression = Generator.Generate(constraint).Single();
            Assert.That(expression, Is.EqualTo(constant));
        }

        [TestCase("A")]
        [TestCase("abc")]
        public void YieldIntConstant_GivenIntConstantOutputConstraint(string value)
        {
            var constant = new Constant<string>(value);
            var constraint = new OutputConstraint(constant);
            var expression = Generator.Generate(constraint).Single();
            Assert.That(expression, Is.EqualTo(constant));
        }
    }
}