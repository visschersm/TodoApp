using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MTech.Utilities.Extensions;

namespace UtilitiesTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestMethod]
        public void IsNullOrEmpty_StringNull_True()
        {
            string str = null!;

            var result = str.IsNullOrEmpty();

            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsNullOrEmpty_StringEmpty_True()
        {
            string str = "";

            var result = str.IsNullOrEmpty();

            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsNullOrEmpty_StringNotEmpty_False()
        {
            string str = "string is not empty";

            var result = str.IsNullOrEmpty();

            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsNullOrEmpty_StringWhiteSpace_False()
        {
            string str = "   ";

            var result = str.IsNullOrEmpty();

            result.Should().BeFalse();
        }

        [TestMethod]
        public void IsNullOrWhiteSpace_StringNull_True()
        {
            string str = null!;

            var result = str.IsNullOrWhiteSpace();

            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsNullOrWhiteSpace_StringEmpty_True()
        {
            string str = "";

            var result = str.IsNullOrWhiteSpace();

            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsNullOrWhiteSpace_StringWhiteSpace_True()
        {
            string str = "   ";

            var result = str.IsNullOrWhiteSpace();

            result.Should().BeTrue();
        }

        [TestMethod]
        public void IsNullOrWhiteSpace_StringNotEmptyOrWhiteSpace_False()
        {
            string str = "string not empty or whitespace";

            var result = str.IsNullOrWhiteSpace();

            result.Should().BeFalse();
        }
    }
}
