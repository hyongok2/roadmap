
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public abstract class PersonBuilder
    {
        protected Person person = new();

        public Person Build()
        {
            return person;
        }
    }
}
