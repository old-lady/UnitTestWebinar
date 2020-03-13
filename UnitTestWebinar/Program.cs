using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestWebinar
{
    class Program
    {
        static void Main(string[] args)
        {
            var result = Calculator.GetTimeZoneOffset("Central Europe Standard Time", DateTime.Now);

            Console.WriteLine(result);
            //PrintTimeZones();

            Console.ReadKey();
        }

        static void PrintTimeZones()
        {
            foreach (TimeZoneInfo z in TimeZoneInfo.GetSystemTimeZones())
                Console.WriteLine(z.Id);
        }
    }
}
