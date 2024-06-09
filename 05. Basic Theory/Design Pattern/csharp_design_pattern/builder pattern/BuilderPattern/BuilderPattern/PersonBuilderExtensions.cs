using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalBuilderPattern
{
    public static class PersonBuilderExtensions
    {
        public static PersonBuilder WorkAs(this PersonBuilder builder, string position) => builder.Do( p => p.Position = position);
    }
}
