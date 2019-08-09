using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CSharp
{
    public static class DriverLicenseUtils
    {

        // this seemed like a good way to keep simple regex rules
        // that they can be shared among the states
        //
        // sample regex:^[a-zA-z]{1}
        // The first character of the string is any alpha upper or lower
        // regex:[0-9]{6}$
        // the last 6 characters of the string is a number
        // so together
        // OneAlphaSixNumeric
        // ^[a-zA-z]{1}[0-9]{6}$
        //
        // These are implemented as an extension method to make
        // it a bit easier to add to the code
        public static bool OneAlphaSixNumeric(this string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-z]{1}[0-9]{6}$");
        }
        public static bool OneAlphaSevenNumeric(this string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-z]{1}[0-9]{7}$");
        }
        public static bool OneAlphaEightNumeric(this string str)
        {
            return Regex.IsMatch(str, @"^[a-zA-z]{1}[0-9]{8}$");
        }
        public static bool NineNumeric(this string str)
        {
            return Regex.IsMatch(str, @"^[0-9]{9}$");
        }
    }
}
