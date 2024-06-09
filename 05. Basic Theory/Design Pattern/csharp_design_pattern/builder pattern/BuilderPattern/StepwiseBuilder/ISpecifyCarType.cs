using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepwiseBuilder
{
    public interface ISpecifyCarType
    {
        public ISpecifyWheelSize OfType(CarType type);
    }
}
