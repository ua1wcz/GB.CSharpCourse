using System;
using System.Collections.Generic;
using System.Text;

namespace Coder
{
    interface ICoder
    {
        string Encode(string s);

        string Decode(string s);
    }
}
