using System;
using System.Linq;

namespace BlockChain
{
    public class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random(DateTime.UtcNow.Millisecond);

            IBlock genesis = new Block(new byte[] {0x00, 0x00 , 0x00 , 0x00 , 0x00 });
            byte[] difficulty = new byte[] { 0x06 , 0x15 };
            
            BlockChain chain = new BlockChain(difficulty, genesis);

            for(int i = 0; i<200;i++ )
            {
                var data = Enumerable.Range(0, 2256).Select(p => (byte)rnd.Next());
                chain.Add(new Block(data.ToArray()));
                Console.WriteLine(chain.LastOrDefault()?.ToString());

                Console.WriteLine("block Chain is Vaild : " + chain.IsValid());
            }
            Console.ReadLine();  
        }
    }
}
