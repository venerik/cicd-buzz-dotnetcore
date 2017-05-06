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
    }
}
