using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFragging
{
    public class Problem
    {
        private readonly List<int> numbers;
        private readonly List<Op> ops;

        public Problem(IEnumerable<int> numbers, IEnumerable<Op> ops)
        {
            this.numbers = new List<int>(numbers);
            this.ops = new List<Op>(ops);
        }

        public int Eval()
        {
            var opGroups = new[]
            {
                new[] {Op.Mul, Op.Div},
                new[] {Op.Add, Op.Sub}
            };
        startAgain:
            foreach (var group in opGroups)
            {
                for (var idx = 0; idx < ops.Count; ++idx)
                {
                    if (group.Contains(ops[idx]))
                    {
                        // evaluate value
                        var op = ops[idx];
                        var result = op.Call(numbers[idx], numbers[idx + 1]);

                        // assume all fractional results are wrong
                        if (result != (int)result)
                            return int.MinValue; // calculation won't work

                        numbers[idx] = (int)result;
                        numbers.RemoveAt(idx + 1);
                        ops.RemoveAt(idx);
                        if (numbers.Count == 1) return numbers[0];
                        goto startAgain; // :)
                    }
                }
            }

            return numbers[0];
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            int i = 0;

            for (; i < ops.Count; ++i)
            {
                sb.Append(numbers[i]);
                sb.Append(ops[i].Name());
            }

            sb.Append(numbers[i]);
            return sb.ToString();
        }
    }


}
