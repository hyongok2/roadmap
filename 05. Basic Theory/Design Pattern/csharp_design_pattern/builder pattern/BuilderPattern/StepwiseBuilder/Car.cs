using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepwiseBuilder
{
    public class Car
    {
        public CarType Type { get; set; }
        public int WheelSize { get; set; }

        public override string ToString()
        {
            return $"Car Info : Type: {Type} / Wheel Size: {WheelSize}";
        }
    }
}
