using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public static class DeepCopyExtensions
    {
        public static T DeepCopy<T>(this IDeepCopyable<T> item)
          where T : new()
        {
            return item.DeepCopy();
        }

        public static T DeepCopy<T>(this T person)
          where T : Person, new()
        {
            return ((IDeepCopyable<T>)person).DeepCopy();
        }
    }
}
