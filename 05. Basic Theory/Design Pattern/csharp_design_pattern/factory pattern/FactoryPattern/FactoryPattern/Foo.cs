using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public class Foo
    {
        private Foo()
        {

        } 

        public async Task<Foo> InitAsync()//여기에 필요한 비동기 작업을 추가한다.
        {
            await Task.Delay(1000);
            return this;
        }

        public static Task<Foo> CreateAsync()
        {
            Foo foo = new Foo();
            return foo.InitAsync();
        }
    }
}
