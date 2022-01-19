using System;
using System.Collections.Generic;
using System.Text;

namespace Coder
{
    struct StructChar
    {
        private List<char> _c;
        private List<char> _ic;

        public StructChar(char a)
        {
            _c = new List<char>();
            if (a == 'a')
            {
                for (int i = 65; i < 91; i++)
                {
                    _c.Add((char)i);
                }
                for (int i = 97; i < 123; i++)
                {
                    _c.Add((char)i);
                }
            }
            if (a == 'r')
            {
                for (int i = 1040; i < 1104; i++)
                {
                    _c.Add((char)i);
                }
            }
            _ic = new List<char>(_c);
            int _count = _c.Count / 2;
            _ic.Reverse(0, _count);
            _ic.Reverse(_count, _count);
        }

        public List<char> C()
        {
            return _c;
        }

        public List<char> IC()
        {
            return _ic;
        }

    }
}
