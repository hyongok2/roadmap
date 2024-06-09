using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public class PersonJobBuilder<TSelf>
      : PersonInfoBuilder<PersonJobBuilder<TSelf>>
      where TSelf : PersonJobBuilder<TSelf>
    {
        public TSelf WorksAsA(string position)
        {
            person.Position = position;
            return (TSelf)this;
        }
    }
}
