using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AbstractFactoryOcp
{
    public class HotDrinkMachine
    {
        private List<Tuple<string, IHotDrinkFactory>> namedFactories =
          new List<Tuple<string, IHotDrinkFactory>>();
        public HotDrinkMachine()
        {
            foreach (var type in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(type) == false) continue;
                if (type.IsInterface) continue;
                if (type.IsEnum) continue;

                namedFactories.Add(Tuple.Create(
                  type.Name.Replace("Factory", string.Empty), (IHotDrinkFactory)Activator.CreateInstance(type)!));
            }
        }

        public IHotDrink MakeDrink()
        {
            Console.WriteLine("Available drinks: ");

            for (int index = 0; index < namedFactories.Count; index++)
            {
                Tuple<string, IHotDrinkFactory>? item = namedFactories[index];
                Console.WriteLine($"{index}: {item.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = Console.ReadLine()!) != null
                    && int.TryParse(s, out int i) // c# 7
                    && i >= 0
                    && i < namedFactories.Count)
                {
                    Console.Write("Specify amount: ");
                    s = Console.ReadLine()!;
                    if (s != null
                        && int.TryParse(s, out int amount)
                        && amount > 0)
                    {
                        return namedFactories[i].Item2.Prepare(amount);
                    }
                }
                Console.WriteLine("Incorrect input, try again.");
            }
        }
    }
}
