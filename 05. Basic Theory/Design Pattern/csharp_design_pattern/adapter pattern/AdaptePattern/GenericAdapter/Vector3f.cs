using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericAdapter
{
    public class Vector3f
      : VectorOfFloat<Vector3f, Dimensions.Three>
    {
        public Vector3f()
        {
        }

        public Vector3f(params float[] values) : base(values)
        {
        }

        public override string ToString()
        {
            return $"{string.Join(",", data)}";
        }

        public static Vector3f operator +
        (Vector3f lhs, Vector3f rhs)
        {
            var result = new Vector3f();
            var dim = new Dimensions.Three().Value;
            for (int i = 0; i < dim; i++)
            {
                result[i] = lhs[i] + rhs[i];
            }

            return result;
        }
    }

}
