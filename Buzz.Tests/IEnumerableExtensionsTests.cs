
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Buzz.Tests
{
    [TestClass]
    public class IEnumerableExtensionsTests
    {
        [TestMethod]
        public void Sample_WithoutSizeFromSingleValueCollection_ReturnsTheSingleValue()
        {
            // Arrange
            var target = new List<string> {"single"};

            // Act
            var actual = target.Sample();

            // Assert
            Assert.AreEqual("single", actual);
        }

        [TestMethod]
        public void Sample_WithoutSizeFromMultiValueCollection_ReturnsRandomSingleValue()
        {
            // Arrange
            var target = GetMultiValueCollection();

            // Act
            var actual = target.Sample();

            // Assert
            Assert.IsTrue(target.Contains(actual));
        }

        [TestMethod]
        public void Sample_WithoutSizeFromEmptyCollection_ThrowsException()
        {
            // Arrange
            var target = new List<string>();

            // Act + Assert 
            Assert.ThrowsException<InvalidOperationException>(() => target.Sample(), "Collection empty.");
        }

        [TestMethod]
        public void Sample_WithSizeFromEmptyCollection_ThrowsException()
        {
            // Arrange
            var target = new List<string>();

            // Act + Assert 
            Assert.ThrowsException<InvalidOperationException>(() => target.Sample(2), "Collection empty.");
        }

        [TestMethod]
        public void Sample_WithSizeLessThanTheSetsSize_ReturnsSamples()
        {
            // Arrange
            var target = GetMultiValueCollection();

            // Act
            var actual = target.Sample(2).ToList();

            // Assert
            Assert.AreEqual(2, actual.Count());
            Assert.IsTrue(target.Contains(actual[0]));
            Assert.IsTrue(target.Contains(actual[1]));
            Assert.AreNotEqual(actual[0], actual[1]);
        }

        [TestMethod]
        public void Sample_SampleSizeIsNegative_ReturnsEmptyCollection()
        {
            // Arrange
            var target = GetMultiValueCollection();

            // Act
            var actual = target.Sample(-1);

            // Assert
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void Sample_SampleSizeIsZero_ReturnsEmptyCollection()
        {
            // Arrange
            var target = GetMultiValueCollection();

            // Act
            var actual = target.Sample(0);

            // Assert
            Assert.AreEqual(0, actual.Count());
        }

        [TestMethod]
        public void Sample_SampleSizeIsSameAsSizeOfSet_ReturnsAllValues()
        {
            // Arrange
            var target = GetMultiValueCollection();

            // Act
            var actual = (List<string> )target.Sample(target.Count);

            // Assert
            CollectionAssert.AreEqual(target, actual);
        }

        [TestMethod]
        public void Sample_SampleSizeIsLargerThanSetOfValues_ReturnsAllValues()
        {
            // Arrange
            var target = GetMultiValueCollection();

            // Act
            var actual = (List<string> )target.Sample(target.Count + 1);

            // Assert
            CollectionAssert.AreEqual(target, actual);
        }

        private static List<string> GetMultiValueCollection()
        {
            return new List<string> { "one", "two", "three" };
        }
    }
}