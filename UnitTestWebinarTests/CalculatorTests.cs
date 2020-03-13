using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestWebinar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace UnitTestWebinar.Tests
{
    [TestClass()]
    public class CalculatorTests
    {
        [TestMethod()]
        public void AdditionTest()

        {
            int i = 5;
            int j = 5;

            int k = Calculator.Addition(i, j);

            Assert.AreEqual(10, k);
        }

        [TestMethod()]
        public void SubstractTest()
        {
            int a = 5;
            int b = 5;

            int k = Calculator.Substract(a, b);
            Assert.AreEqual(0, k);
        }

        // øvelse 01
        [TestMethod()]
        public void AverageTest()
        {
            List<int> myCollection = new List<int> { 3, 4, 1, 6, 7, 4, 7, 8, 9, 2, 3 };

            double averageCorrect = (double)getSum(myCollection) / (double)myCollection.Count;
            double methodResult = Calculator.Average(myCollection);

            Assert.AreEqual(averageCorrect, methodResult);
        }
        private int getSum(ICollection<int> numbers)
        {
            int result = 0;
            foreach (int item in numbers)
            {
                result += item;
            }
            return result;
        }

        [TestMethod()]
        public void DivideTest()
        {
            int i = 10;
            int j = 5;

            int test = Calculator.Divide(10, 5);
            Assert.AreEqual(2, test);
        }

        [TestMethod()]
        public void IsPrimeTest()
        {
            int prime = 113;
            bool isprime = Calculator.IsPrime(prime);
            Assert.AreEqual(true, isprime);
        }
        [TestMethod()]
        public void IsNotPrimeTest()
        {
            int prime = 114;
            bool isprime = Calculator.IsPrime(prime);
            Assert.AreEqual(false, isprime);

        }

        [TestMethod()]
        public void FactorialTest()
        {
            int result = Calculator.Factorial(10);
            int realResult = 3628800;

            Assert.AreEqual(realResult, result);
        }

        [TestMethod()]
        public void IsLeapYearTest()
        {
            List<DateTime> leapyears = new List<DateTime> { new DateTime(2020, 1, 1), new DateTime(2024, 1, 1), new DateTime(2080, 1, 1) };

            foreach (var item in leapyears)
            {

                Assert.AreEqual(true, Calculator.IsLeapYear(item));
            }
        }

        [TestMethod()]
        public void IsValidHumanTemperatureTest()
        {
            List<double> validTemp = new List<double> { 39.2, 38.3, 40 };

            foreach (var item in validTemp)
            {
                Assert.AreEqual(true, Calculator.IsValidHumanTemperature(item));

            }
        }

        [TestMethod()]
        public void IsNotValidHumanTemperatureTest1()
        {
            List<double> notValidTemp = new List<double> { 2, -10, 400 };

            foreach (var item in notValidTemp)
            {
                Assert.AreEqual(false, Calculator.IsValidHumanTemperature(item));

            }
        }

        [TestMethod()]
        public void GetFilenameFromPathTest()
        {
            string path = @"C:\Users\Julia\Documents\Dania\2.semester\SysVirk21\Test\Øvelser  Unitest -20200313";
            string fileName = @"Øvelser  Unitest -20200313";

            Assert.AreEqual(fileName, Calculator.GetFilenameFromPath(path));
        }

        [TestMethod()]
        public void IsValidEmailTest()
        {
            string ValidEmail = @"JuliaMySommer@gmail.com";
            Assert.AreEqual(true, Calculator.IsValidEmail(ValidEmail));
        }

        [TestMethod()]
        public void TruncateByWordsWithEllipsisTest()
        {
            string stringToTest = @"Ground control to Major Tom.";
            int testLength = 20;
            string validResult = @"Ground control to...";

            Assert.AreEqual(validResult, Calculator.TruncateByWordsWithEllipsis(stringToTest, testLength));
        }

        [TestMethod()]
        public void RightTest()
        {
            string stringToTest = @"Ground control to Major Tom.";
            int testLength = 4;
            string validResult = @"Tom.";

            Assert.AreEqual(validResult, Calculator.Right(stringToTest, testLength));
        }

        [TestMethod()]
        public void SerializeToXmlStringTest()
        {

            string testingString = "Ground control to Major Tom.";
            string validResult = "<?xml version=\"1.0\" encoding=\"utf-16\"?>\r\n<string>Ground control to Major Tom.</string>";


            Assert.AreEqual(validResult, Calculator.SerializeToXmlString(testingString));
        }

        [TestMethod()]
        public void WriteToFileTest()
        {
            string testingString = "Ground control to Major Tom.";
            string path = @"C:\Users\Julia\Documents\Dania\2.semester\SysVirk21\Test\Øvelser  Unitest -20200313\Testing";

            string whatIsWritten = File.ReadAllText(path);

            Calculator.WriteToFile(testingString, path);
            Assert.AreEqual(testingString, whatIsWritten);
        }

        // Øvelse 16
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ThrowIfLessThanTest()
        {
            int number = 0;
            int limit = 10;

            Calculator.ThrowIfLessThan(number, limit, "Too small");
        }

        // Øvelse 17

        [TestMethod()]
        public void GetTimeZoneOffsetTest()
        {

            string timeZone = "Central Europe Standard Time";
            DateTime dateTime = DateTime.Now;
            TimeSpan timeSpan = new TimeSpan(1, 0, 0);

            Assert.AreEqual(timeSpan, Calculator.GetTimeZoneOffset(timeZone, dateTime));
        }

        // Øvelse 18 (Mangler)

        [TestMethod()]
        public void GetCookieValueTest()
        {
            Assert.Fail();
        }

        // Øvelse 19 (Mangler)
        [TestMethod()]
        public void GetHeaderValueTest()
        {
            Assert.Fail();
        }

        // Øvelse 20
        [TestMethod()]
        public void ParseIntegerOrNullTest()
        {
            string i = "dfgd";
            string j = "20";

            Assert.AreEqual(null, Calculator.ParseIntegerOrNull(i));
            Assert.AreEqual(20, Calculator.ParseIntegerOrNull(j));
        }
    }
}