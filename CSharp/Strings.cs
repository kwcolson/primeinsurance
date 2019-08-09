using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp
{
    public static class Strings
    {
        /// <summary>
        /// Implement a string reversal method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Reverse1(string input)
        {
            return string.Concat(input.Reverse());
        }

        /// <summary>
        /// Implement a different string reversal method
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string Reverse2(string input)
        {
            var returnVal = "";
            // start at the end and make populate our new string
            for(var i = input.Length -1; i >= 0; i--)
            {
                returnVal = returnVal + input[i];
            }
            return returnVal;
        }


        /// <summary>
        /// Implement a string truncation function that safely truncates the input without throwning an exception. Return null if input is null.
        /// </summary>
        /// <param name="input"></param>
        /// <param name="length"></param>
        /// <returns></returns>
        public static string SafeTruncate(string input, int length)
        {
            if (input == null)
                return null;
            return input.Substring(0, Math.Min(input.Length, length));
        }

        /// <summary>
        /// return a list of even numbers from the input.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static List<int> EvenNumerics(List<string> input)
        {
            var evenList = new List<int>();

            foreach (var item in input)
            {
                var x = 0;
                // do we have an integer?
                if(Int32.TryParse(item, out x)){
                    // is it even?
                    if (x % 2 == 0)
                        evenList.Add(x);
                }
            }
            return evenList;
        }
    }
}
