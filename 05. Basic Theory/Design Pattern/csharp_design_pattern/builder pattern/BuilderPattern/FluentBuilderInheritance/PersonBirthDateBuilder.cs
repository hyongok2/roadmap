using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public class PersonBirthDateBuilder<TSelf>
      : PersonJobBuilder<PersonBirthDateBuilder<TSelf>>
      where TSelf : PersonBirthDateBuilder<TSelf>
    {
        public TSelf Born(DateTime dateOfBirth)
        {
            person.DateOfBirth = dateOfBirth;
            return (TSelf)this;
        }
    }
}
