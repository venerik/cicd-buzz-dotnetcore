using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Buzz.Tests
{
    [TestClass]
    public class GeneratorTests
    {
        [TestMethod]
        public void Sample_WithoutSize_ReturnsASingleValue()
        {
            // Arrange
            var values = new [] {"a", "b", "c"};
            var target = new Generator();

            // Act
            var actual = target.Sample(values);

            // Assert
            Assert.AreNotEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Sample_WithSizeLessThanTheSetsSize_ReturnsSamples()
        {
            // Arrange
            var values = new List<string> {"a", "b", "c"};
            var target = new Generator();

            // Act
            var actual = target.Sample(values, 2);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(values.Contains(actual[0]));
            Assert.IsTrue(values.Contains(actual[1]));
            Assert.AreNotEqual(actual[0], actual[1]);
        }
    }
}
