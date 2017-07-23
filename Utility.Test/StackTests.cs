using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace CDD.Utility.Test
{
    [TestFixture]
    public class StackTests
    {
        [Test]
        public void StackCreatedFromEnumerationPopsLastFirst()
        {
            var numbers = new[] {1, 2, 3, 4, 5};
            var stack = new Stack<int>(numbers);
            var top = stack.Pop();
            Assert.That(top, Is.EqualTo(numbers.Last()));
        }
    }
}
