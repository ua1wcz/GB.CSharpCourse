using System;
using System.Collections.Generic;
using System.Text;

namespace Coder
{
    class ACoder : ICoder
    {
        StructChar scA = new StructChar('a');
        StructChar scR = new StructChar('r');
        List<char> lcA;

        private StructChar SearchStruct(char _ch)
        {
            int ind = scR.C().IndexOf(_ch);
            if (ind != -1)
            {
                return scR;
            }
            return scA;
        }
        private char FindChar(char _ch, bool sign)
        {
            int j = 0;
            lcA = SearchStruct(_ch).C();
            int ind = lcA.IndexOf(_ch);
            if (ind == -1)
            {
                return _ch;
            }
            if (sign)
            {
                j = ind >= lcA.Count - 1 ? 0 : ind + 1 ;
            }
            else
            {
                j = ind <= 0 ? lcA.Count - 1 : ind - 1;
            }
            return lcA[j];
        }

        private string MultiCoder(string s, bool sign)
        {
            char[] ch = s.ToCharArray();

            for (int i = 0; i < ch.Length; i++)
            {
                ch[i] = FindChar(ch[i], sign);
            }

            return new string(ch);
        }
        public string Decode(string s)
        {
            return MultiCoder(s, false);
            throw new NotImplementedException();
        }

        public string Encode(string s)
        {
            return MultiCoder(s, true);
            throw new NotImplementedException();
        }
    }
}
