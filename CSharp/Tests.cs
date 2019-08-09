using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;


namespace CSharp
{
    public class Tests
    {
        [Theory]
        [InlineData("abc", "cba")]
        [InlineData("123", "321")]
        [InlineData("PrimeInsurance", "ecnarusnIemirP")]
        public void ReverseTest(string input, string expected)
        {
            Assert.Equal(Strings.Reverse1(input), expected);
            Assert.Equal(Strings.Reverse2(input), expected);
        }

        [Theory]
        [InlineData("8722 S. Harrison Street", 10, "8722 S. Ha")]
        [InlineData("8722 S. Harrison Street", 50, "8722 S. Harrison Street")]
        [InlineData(null, 50, null)]
        public void SafeTruncate(string input, int length, string expected)
        {
            Assert.Equal(Strings.SafeTruncate(input, length), expected);
        }

        [Theory]
        [InlineData("A12345678", "NE", true)]
        [InlineData("A123", "NE", false)]
        [InlineData("A12345678", "MS", false)]
        [InlineData("012345678", "MS", true)]
        [InlineData("012345678", "", false)]
        [InlineData("012345678", null, false)]
        [InlineData(null, "ON", false)]
        public void ValidateDriverLicense(string license, string state, bool valid)
        {
            Assert.Equal(DriverLicense.Validate(license, state), valid);
        }

        [Theory]
        [InlineData(new string[] { "A", "CC", "1", "2", "5", "6" }, new int[] { 2, 6 })]
        [InlineData(new string[] { "O", "X", "1", "12", "5", "8" }, new int[] { 12, 8 })]
        public void EvenNumerics(string[] input, int[] expected)
        {
            var i = input.ToList();
            var e = expected.ToList();

            Assert.Equal(Strings.EvenNumerics(i), e);

        }

        // these are the tests that I wrote as I was developing the
        // validations, I figured there was no need to delete them
        [Theory]
        [InlineData("", false)]
        [InlineData("111", false)]
        [InlineData("!@#", false)]
        [InlineData("Aa12345", false)]
        [InlineData("A123456", true)]
        [InlineData("aaa12345", false)]
        [InlineData("aA1234567", false)]
        [InlineData("aA12345678", false)]
        public void IsOneAlphaSixNumeric(string str, bool valid)
        {
            Assert.Equal(DriverLicenseUtils.OneAlphaSixNumeric(str), valid);
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("111", false)]
        [InlineData("!@#", false)]
        [InlineData("Aa12345", false)]
        [InlineData("Aa123456", false)]
        [InlineData("aaa12345", false)]
        [InlineData("a1234567", true)]
        [InlineData("aA12345678", false)]
        public void IsOneAlphaSevenNumeric(string str, bool valid)
        {
            Assert.Equal(DriverLicenseUtils.OneAlphaSevenNumeric(str), valid);
        }
        [Theory]
        [InlineData("", false)]
        [InlineData("111", false)]
        [InlineData("!@#", false)]
        [InlineData("Aa12345", false)]
        [InlineData("Aa123456", false)]
        [InlineData("aaa12345", false)]
        [InlineData("aA1234567", false)]
        [InlineData("A12345678", true)]
        public void IsOneAlphaEightNumeric(string str, bool valid)
        {
            Assert.Equal(DriverLicenseUtils.OneAlphaEightNumeric(str), valid);
        }
    }
}
