using AbstractFactory;

var machine = new HotDrinkMachine();
IHotDrink drink = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 3);
drink.Consume();