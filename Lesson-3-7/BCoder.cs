using System;
using System.Collections.Generic;
using System.Text;

namespace Coder
{
    class BCoder : ICoder
    {
        StructChar scA = new StructChar('a');
        StructChar scR = new StructChar('r');
        List<char> lcA;
        List<char> lcA_revers;

        private int _ind;

        private int Ind 
        {
            get { return _ind; }
            set 
            {
                _ind = value;
            }
        }

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
            char c;
            int j = 0;
            StructChar s = SearchStruct(_ch);
            lcA = s.C();
            lcA_revers = s.IC();
            Ind = lcA.IndexOf(_ch);
            if (Ind == -1)
            {
                return _ch;
            }
            c = sign ? lcA_revers[lcA.IndexOf(_ch)] : lcA[lcA_revers.IndexOf(_ch)];
            return c;
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