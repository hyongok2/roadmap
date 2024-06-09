using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepwiseBuilder
{
    public interface ISpecifyWheelSize
    {
        public IBuildCar WithWheels(int size);
    }
}
