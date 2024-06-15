using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FacetedBuilder
{
    public class PersonBuilder // facade 
    {
        // the object we're going to build
        protected Person person = new(); // this is a reference!

        public PersonAddressBuilder Lives => new(person);
        public PersonJobBuilder Works => new(person);

        public static implicit operator Person(PersonBuilder pb)
        {
            return pb.person;
        }
    }
}
