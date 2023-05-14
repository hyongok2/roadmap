using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public interface IBlock
    {
        byte[] Data { get; }
        byte[] Hash { get; set; }
        int Nonce { get; set; }
        byte[] PrevHash { get; set; }
        DateTime TimeStamp { get;}
    }
}
