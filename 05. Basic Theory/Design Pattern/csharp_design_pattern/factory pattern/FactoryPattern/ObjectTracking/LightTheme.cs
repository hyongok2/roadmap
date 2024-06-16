using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTracking
{
    class LightTheme : ITheme
    {
        public string TextColor => "black";
        public string BgrColor => "white";
    }
}
