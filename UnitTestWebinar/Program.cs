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
            //string fullPath = @"C:\Users\Julia\Documents\Dania\2.semester\SysVirk21\Test\Øvelser  Unitest -20200313";
            //Console.WriteLine(Path.GetFileName(fullPath));


            string path = @"C:\Users\Julia\Documents\Dania\2.semester\SysVirk21\Test\Øvelser  Unitest -20200313\Testing";
            Calculator.WriteToFile("Ah", path);

            string whatIsWritten = File.ReadAllText(path);
            Console.WriteLine(whatIsWritten);

            Console.ReadKey();
        }
    }
}
