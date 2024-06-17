using AbstractFactoryOcp;

var machine = new HotDrinkMachine();

var drink = machine.MakeDrink();

drink.Consume();
