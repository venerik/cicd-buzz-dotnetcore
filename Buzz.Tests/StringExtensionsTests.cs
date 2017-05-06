using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Buzz.Tests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void ToTitleCase_GivenEmptyString_ReturnsEmptyString()
        {
            var actual = string.Empty.ToTitleCase();

            Assert.AreEqual(string.Empty, actual);
        }

        [TestMethod]
        public void ToTitleCase_GivenSingleLowercaseString_ReturnsWithFirstLetterCapitalized()
        {
            var actual = "test".ToTitleCase();

            Assert.AreEqual("Test", actual);
        }
       

        [TestMethod]
        public void ToTitleCase_GivenTitleCasedString_ReturnsWithFirstLetterCapitalized()
        {
            var actual = "Test".ToTitleCase();

            Assert.AreEqual("Test", actual);
        }

        [TestMethod]
        public void ToTitleCase_GivenSingleUppercaseString_ReturnsWithFirstLetterCapitalized()
        {
            var actual = "TEST".ToTitleCase();

            Assert.AreEqual("Test", actual);
        } 
       
        [TestMethod]
        public void ToTitleCase_GivenStringWithMultipleLowercaseWords_ReturnsAllWordsWithFirstLetterCapitalized()
        {
            var actual = "test test".ToTitleCase();

            Assert.AreEqual("Test Test", actual);
        } 
       
        [TestMethod]
        public void ToTitleCase_GivenStringWithWordsSeperatedWithDots_ReturnsAllWordsWithFirstLetterCapitalized()
        {
            var actual = "test.test".ToTitleCase();

            Assert.AreEqual("Test.Test", actual);
        } 
    }
}
