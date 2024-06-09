using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FluentBuilderInheritance
{
    public class Person
    {
        public string? Name { get; set; }

        public string? Position { get; set; }

        public DateTime DateOfBirth { get; set; }

        public class Builder : PersonBirthDateBuilder<Builder>
        {
        }

        public static Builder New => new();

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, {nameof(Position)}: {Position}";
        }
    }
}
