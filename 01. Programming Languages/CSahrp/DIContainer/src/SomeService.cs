using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
    public class SomeService : ISomeService
    {
       // private Guid _ramdomGuid = Guid.NewGuid();

        private readonly IRandomGuidProvider _randomGuidProvider;

        public SomeService(IRandomGuidProvider randomGuidProvider)
        {
            _randomGuidProvider = randomGuidProvider;
        }

        public void PrintSomething()
        {
           Console.WriteLine(_randomGuidProvider.RandomGuid.ToString());   
        }
    }
}
