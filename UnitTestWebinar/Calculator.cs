using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace UnitTestWebinar
{
    public static class Calculator
    {
        public static int Addition (int number, int number2)
        {
            return number + number2;
        }
        public static int Substract (int number1, int number2)
        {
            return 0;
        }

        // Øvelse 02

        /// <summary>
        /// Calculates averages the specified collection.
        /// </summary>
        /// <param name="collection">The collection.</param>
        /// <returns>Averages value of input collection.</returns>
        public static double Average(List<int> collection)
        {
            return collection.Sum() / (double)collection.Count;
        }

        // Øvelse 03

        /// <summary>
        /// Divides the specified values.
        /// </summary>
        /// <param name="i">The divider.</param>
        /// <param name="j">The dividend.</param>
        /// <returns>Quotient.</returns>
        public static int Divide(int i, int j)
        {
            return i / j;
        }

        // Øvelse 04 (Prime)

        /// <summary>
        /// Determines whether the specified number is prime.
        /// </summary>
        /// <param name="candidate">The candidate value.</param>
        /// <returns>True when number is prime, otherwise false.</returns>
        public static bool IsPrime(int candidate)
        {
            // Test whether the parameter is a prime number.
            if ((candidate & 1) == 0)  //<---- new operator :O
            {
                if (candidate == 2)
                {
                    return true;
                }

                return false;
            }

            for (int i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }

            return candidate != 1;
        }

        // Øvelse 5

        /// <summary>
        /// Calculates factorials of the specified input.
        /// </summary>
        /// <param name="i">The input to calculate.</param>
        /// <returns>Factorial </returns>
        public static int Factorial(int i)
        {
            if (i <= 1)
            {
                return 1;
            }

            return i * Factorial(i - 1);
        }

        // Øvelse 6

        /// <summary>
        /// Determines whether the specified date is in leap year.
        /// </summary>
        /// <param name="date">The date to calculate.</param>
        /// <returns>True, when date in leap year, otherwise false</returns>
        public static bool IsLeapYear(DateTime date)
        {
            return DateTime.IsLeapYear(date.Year);
        }

        // Øvelse 7

        /// <summary>
        /// Determines whether the specified value is valid human temperature.
        /// </summary>
        /// <param name="temp">The Temperature.</param>
        /// <returns>True, when temperature is valid, otherwise false.</returns>
        public static bool IsValidHumanTemperature(double temp)
        {
            return temp > 35.5 && temp <= 43.2;
        }

        // Øvelse 8

        /// <summary>
        /// Gets the filename from fullPath.
        /// </summary>
        /// <param name="fullPath">The fullPath.</param>
        /// <returns>The file name.</returns>
        public static string GetFilenameFromPath(string fullPath)
        {
            return Path.GetFileName(fullPath);
        }

        // Øvelse 9

        /// <summary>
        /// Determines whether the specified string is valid email.
        /// </summary>
        /// <param name="strIn">The string input.</param>
        /// <returns>True, when input email is valid, otherwise false.</returns>
        public static bool IsValidEmail(string strIn)
        {
            if (string.IsNullOrEmpty(strIn))
            {
                return false;
            }

            // Return true if strIn is in valid e-mail format. 
            try
            {
                return Regex.IsMatch(
                    strIn,
                    @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))"
                    + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
                    RegexOptions.IgnoreCase,
                    TimeSpan.FromMilliseconds(250));
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }
        }

        // Øvelse 10

        /// <summary>
        /// Truncates the specified string without breaking a word in half.
        /// If input string was truncated, the suffix will be added to end of output string.
        /// </summary>
        /// <param name="str">The input string to truncate.</param>
        /// <param name="maxLength">Max length of output string, including specified suffix.</param>
        /// <param name="suffix">The suffix, which will be added to end of the truncated string.</param>
        /// <returns>If length of input string more then maximum allowed - returns truncated string, otherwise original string.</returns>
        /// <example>
        /// For string "hello big world" with maxLength = 12 returns "hello big...".
        /// </example>
        public static string TruncateByWordsWithEllipsis(this string str, int maxLength, string suffix = "...")
        {
            if (maxLength < suffix.Length)
            {
                // We don't want to do anything with invalid data.
                return string.Empty;
            }

            if (str.Length > maxLength)
            {
                str = str.Substring(0, maxLength - suffix.Length + 1);
                str = str.Substring(0, Math.Min(str.Length, str.LastIndexOf(" ", StringComparison.Ordinal) == -1 ? 0 : str.LastIndexOf(" ", StringComparison.Ordinal)));
                str = str + suffix;
            }

            return str.Trim();
        }

        // Øvelse 11

        /// <summary>
        /// Truncates string and returns right part of it.
        /// </summary>
        /// <param name="value">The value to truncate.</param>
        /// <param name="maxLength">The maximum length of return value.</param>
        /// <returns>Right part of the string.</returns>
        public static string Right(this string value, int maxLength)
        {
            // Check if the value is valid.
            if (string.IsNullOrEmpty(value))
            {
                // Set valid empty string as string could be null.
                value = string.Empty;
            }
            else if (value.Length > maxLength)
            {
                // Make the string no longer than the max length.
                value = value.Substring(value.Length - maxLength, maxLength);
            }

            // Return the truncated string.
            return value;
        }

        // Øvelse 12

        /// <summary>
        /// Serializes the specified object to XML string.
        /// </summary>
        /// <param name="objectInstance">The object instance to serialize.</param>
        /// <param name="cleanNameSpaces">
        /// Specifies whether to serialize classes into XMl without the Namespaces.
        /// If yes then namespaces is not added. By default is set to <c>false</c>.
        /// </param>
        /// <returns>The string which contain object definition in XML format.</returns>
        public static string SerializeToXmlString(this object objectInstance)
        {
            XmlSerializer serializer = new XmlSerializer(objectInstance.GetType());
            StringBuilder sb = new StringBuilder();

            using (TextWriter writer = new StringWriter(sb))
            {
                serializer.Serialize(writer, objectInstance);
            }

            return sb.ToString();
        }

        // Øvelser 13

        /// <summary>
        /// Writes specified text to file.
        /// </summary>
        /// <param name="text">The text to write.</param>
        /// <param name="file">The file.</param>
        public static void WriteToFile(string text, string file)
        {
            // WriteAllText creates a file, writes the specified string to the file, // and then closes the file.
            File.WriteAllText(file, text);
        }

        // Øvelse 14


    }

    
}
