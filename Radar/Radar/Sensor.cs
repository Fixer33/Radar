using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Radar
{
    public class Sensor
    {
        public int Number;
        public float Distance;
        public float Angle;

        public Sensor(int number, float distance, float angle)
        {
            this.Number = number;
            this.Distance = distance;
            this.Angle = angle;
        }

    }
}
