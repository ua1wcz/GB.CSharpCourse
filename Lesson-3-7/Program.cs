using System;
using System.Collections.Generic;

namespace Coder
{
    class Program
    {
        static void Main(string[] args)
        {
            string s = "ABCxyz 1 АБВэюя";
            Console.WriteLine($"Original string - {s}");
            Console.WriteLine();

            ACoder ac1 = new ACoder();
            string s1 = ac1.Encode(s);
            Console.WriteLine($"Encode - {s1}");
            Console.WriteLine();

            string s2 = ac1.Decode(s1);
            Console.WriteLine($"Decode - {s2}");
            Console.WriteLine();

            BCoder bc1 = new BCoder();
            string s3 = bc1.Encode(s);
            Console.WriteLine($"Encode - {s3}");
            Console.WriteLine();

            string s4 = bc1.Decode(s3);
            Console.WriteLine($"Decode - {s4}");
            Console.WriteLine();

            Console.WriteLine("Hello World!");
        }
    }
}
