using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTestWebinar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestWebinar.Tests
{
    [TestClass()]
    public class CarTests
    {
        // Øvelse 14
        [TestMethod()]
        public void AccelerateTest()
        {
            Car car = new Car();
            car.Accelerate();
            Assert.AreEqual(20, car.Speed);
        }
    }
}