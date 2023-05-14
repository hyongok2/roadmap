using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockChain
{
    public class BlockChain : IEnumerable<IBlock>
    {
        private List<IBlock> _items = new List<IBlock>();

        public BlockChain(byte[] difficulty, IBlock genesis)
        {
            Difficulty= difficulty;
            genesis.Hash = genesis.MineHash(difficulty);
            Items.Add(genesis);
        }

        public void Add(IBlock item)
        {
            if(Items.LastOrDefault() !=null)
            {
                item.PrevHash = Items.LastOrDefault()?.Hash;
            }
            item.Hash = item.MineHash(Difficulty);
            Items.Add(item);
        }

        public int Count => Items.Count;
        public IBlock this[int index]
        {
            get { return Items[index]; }
            set { Items[index] = value; }
        }
        public List<IBlock> Items 
        { 
            get { return _items; }
            set { _items = value; }
        }
        public byte[] Difficulty
        {
            get;
        }


        public IEnumerator<IBlock> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Items.GetEnumerator();
        }
    }
}
