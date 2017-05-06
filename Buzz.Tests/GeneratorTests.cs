using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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
            var values = GetDefaultValues();
            var target = GetDefaultGenerator();

            // Act
            var actual = target.Sample(values);

            // Assert
            Assert.AreNotEqual(string.Empty, actual);
        }

        [TestMethod]
        public void Sample_WithSizeLessThanTheSetsSize_ReturnsSamples()
        {
            // Arrange
            var values = GetDefaultValues();
            var target = GetDefaultGenerator();

            // Act
            var actual = target.Sample(values, 2);

            // Assert
            Assert.AreEqual(2, actual.Count);
            Assert.IsTrue(values.Contains(actual[0]));
            Assert.IsTrue(values.Contains(actual[1]));
            Assert.AreNotEqual(actual[0], actual[1]);
        }

        [TestMethod]
        public void Sample_SampleSizeIsNegative_ReturnsEmptyCollection()
        {
            // Arrange
            var values = GetDefaultValues();
            var target = GetDefaultGenerator();

            // Act
            var actual = target.Sample(values, -1);

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Sample_SampleSizeIsZero_ReturnsEmptyCollection()
        {
            // Arrange
            var values = GetDefaultValues();
            var target = GetDefaultGenerator();

            // Act
            var actual = target.Sample(values, 0);

            // Assert
            Assert.AreEqual(0, actual.Count);
        }

        [TestMethod]
        public void Sample_SampleSizeIsSameAsSizeOfSet_ReturnsAllValues()
        {
            // Arrange
            var values = GetDefaultValues();
            var target = GetDefaultGenerator();

            // Act
            var actual = (List<string> )target.Sample(values, values.Count);

            // Assert
            CollectionAssert.AreEqual(values, actual);
        }

        [TestMethod]
        public void Sample_SampleSizeIsLargerThanSetOfValues_ReturnsAllValues()
        {
            // Arrange
            var values = GetDefaultValues();
            var target = GetDefaultGenerator();

            // Act
            var actual = (List<string> )target.Sample(values, values.Count + 1);

            // Assert
            CollectionAssert.AreEqual(values, actual);
        }

        [TestMethod]
        public void Buzz_InAllCases_ReturnsTitleCasedPhrase()
        {
            // Arrange
            var target = GetDefaultGenerator();

            // Act
            var actual = target.Buzz();

            // Assert
            Assert.IsTrue(Regex.IsMatch(actual, @"^(\b[A-Z0-9][\w]*\b[\s\.-]*)*$"));
        }

        private static Generator GetDefaultGenerator()
        {
            return new Generator();
        }

        private static List<string> GetDefaultValues()
        {
            return new List<string> { "one", "two", "three" };
        }
    }
}
