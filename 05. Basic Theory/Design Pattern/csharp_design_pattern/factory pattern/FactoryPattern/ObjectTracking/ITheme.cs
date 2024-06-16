using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTracking
{
    public interface ITheme
    {
        string TextColor { get; }
        string BgrColor { get; }
    }
}
