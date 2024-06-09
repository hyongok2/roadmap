
using FluentBuilderInheritance;

var you = Person.New.Called("David")
                    .WorksAsA("Sales")
                    .Born(DateTime.Now)
                    .Build();

Console.WriteLine(you);