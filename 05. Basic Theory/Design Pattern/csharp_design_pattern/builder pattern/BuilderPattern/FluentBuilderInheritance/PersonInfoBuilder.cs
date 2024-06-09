using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public class PersonInfoBuilder<TSelf> : PersonBuilder
      where TSelf : PersonInfoBuilder<TSelf>
    {
        public TSelf Called(string name)
        {
            person.Name = name;
            return (TSelf)this;
        }
    }
}
