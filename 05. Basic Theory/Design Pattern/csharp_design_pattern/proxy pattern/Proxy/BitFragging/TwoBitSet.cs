using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitFragging
{

    public class TwoBitSet
    {
        // 64 bits --> 32 values
        private readonly ulong data;

        public TwoBitSet(ulong data)
        {
            this.data = data;
        }

        public byte this[int index]
        {
            get
            {
                var shift = index << 1;
                ulong mask = (0b11U << shift);
                return (byte)((data & mask) >> shift);
            }
        }
    }
}
