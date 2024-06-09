using StepwiseBuilder;

var car = CarBuilder.Create()
                    .OfType(CarType.Sedan)
                    .WithWheels(15)
                    .Build();

Console.WriteLine(car);