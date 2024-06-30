using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAdapter
{
    public class VectorOfFloat<TSelf, D>
      : Vector<TSelf, float, D>
      where D : IInteger, new()
      where TSelf : Vector<TSelf, float, D>, new()
    {
        public VectorOfFloat()
        {
        }

        public VectorOfFloat(params float[] values) : base(values)
        {
        }

        public static VectorOfFloat<TSelf, D> operator +
            (VectorOfFloat<TSelf, D> lhs, VectorOfFloat<TSelf, D> rhs)
        {
            var result = new VectorOfFloat<TSelf, D>();
            var dim = new D().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }

            return result;
        }
    }
}
