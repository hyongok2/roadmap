using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StepwiseBuilder
{
    public class CarBuilder
    {
        public static ISpecifyCarType Create()
        {
            return new Impl();
        }

        private class Impl :
          ISpecifyCarType,
          ISpecifyWheelSize,
          IBuildCar
        {
            private readonly Car car = new();

            public ISpecifyWheelSize OfType(CarType type)
            {
                car.Type = type;
                return this;
            }

            public IBuildCar WithWheels(int size)
            {
                switch (car.Type)
                {
                    case CarType.Crossover when size < 17 || size > 20:
                    case CarType.Sedan when size < 15 || size > 17:
                        throw new ArgumentException($"Wrong size of wheel for {car.Type}.");
                }
                car.WheelSize = size;
                return this;
            }

            public Car Build()
            {
                return car;
            }
        }
    }

}
