using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitTestWebinar
{
    public class Car
    {
        /// <summary>
        /// Gets the car speed.
        /// </summary>
        public int Speed { get; private set; }

        /// <summary>
        /// Accelerates this car speed.
        /// </summary>
        public void Accelerate()
        {
            this.Speed += 20;
        }
    }
}
