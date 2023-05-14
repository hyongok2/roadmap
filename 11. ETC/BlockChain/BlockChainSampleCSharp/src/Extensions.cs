using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public static class Extensions
    {
        public static byte[] GenerateHash(this IBlock block)
        {
            using (SHA512 sha = new SHA512Managed())
            using (MemoryStream ms = new MemoryStream())
            using (BinaryWriter bw = new BinaryWriter(ms))
            {
                bw.Write(block.Data);
                bw.Write(block.Nonce);
                bw.Write(block.TimeStamp.ToBinary());
                bw.Write(block.PrevHash);
                var msArr = ms.ToArray();
                return sha.ComputeHash(msArr);
            }
        }
        public static byte[] MineHash(this IBlock block, byte[] difficulty)
        {
            if(difficulty == null) throw new ArgumentNullException(nameof(difficulty));

            byte[] hash = new byte[0];
            int d = difficulty.Length;
            while(!hash.Take(d).SequenceEqual(difficulty))
            {
                block.Nonce++;
                hash = block.GenerateHash();
            }

            return hash;
        }

        public static bool IsValid(this IBlock block)
        {
            var bk = block.GenerateHash();
            return block.Hash.SequenceEqual(bk);
        }

        public static bool IsValidPrevblock(this IBlock block, IBlock prevBlock)
        {
            if (prevBlock == null) throw new ArgumentNullException(nameof(prevBlock));

            var prev = prevBlock.GenerateHash();
            return prevBlock.IsValid() && block.PrevHash.SequenceEqual(prev);
        }

        public static bool IsValid(this IEnumerable<IBlock> items) 
        {
            var enmerable = items.ToList();
            return enmerable.Zip(enmerable.Skip(1), Tuple.Create).All(block => block.Item2.IsValid() && block.Item2.IsValidPrevblock(block.Item1));
        }

    }
}
