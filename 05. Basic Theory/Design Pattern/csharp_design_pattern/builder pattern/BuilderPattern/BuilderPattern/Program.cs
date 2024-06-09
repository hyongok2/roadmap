using FunctionalBuilderPattern;

var person = new PersonBuilder().Called("jeremy").WorkAs("engineer").Build();

Console.WriteLine(person.Name + " " + person.Position);