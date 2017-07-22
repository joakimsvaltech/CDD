using NUnit.Framework;

namespace CDD.Core.Test
{
    [TestFixture]
    public class Generators
    {
        [Test]
        public void YieldNoExpressions_GivenNoConstraint() 
        {
            var expressions = new GeneratorImpl().Generate();
            Assert.That(expressions, Is.Empty);
        }
    }
}