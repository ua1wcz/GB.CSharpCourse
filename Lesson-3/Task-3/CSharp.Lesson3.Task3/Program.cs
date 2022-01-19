using System;

namespace CSharp.Lesson3.Task3
{
    class Program
    {
        static void Main()
        {
            WelcomeScreen();
        }

        private static void WelcomeScreen()
        {
            Console.WriteLine("Reverse sort examples\n");
            Console.WriteLine("1) Using Array.Reverce");
            Console.WriteLine("2) Using for loop");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Example1();
                    WelcomeScreen();
                    break;
                case "2":
                    Example2();
                    WelcomeScreen();
                    break;
                case "4":
                    return;
                default:
                    Console.WriteLine("Incorrect value. Please, try again");
                    return;
            }
        }

        private static void Example1()
        {
            Console.Write("\r\nEnter any word (example 1): ");
            var input = Console.ReadLine();
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            Console.WriteLine(charArray);
            Console.WriteLine("\n");
        }

        private static void Example2()
        {
            Console.Write("\r\nEnter any word (example 2): ");
            var input = Console.ReadLine();
            var charArray = input.ToCharArray();
            var charUpperBound = charArray.GetUpperBound(0);
            for (int i = 0; i <= charUpperBound; charUpperBound--)
            {
                Console.Write(charArray[charUpperBound]);
            }
            Console.WriteLine("\n");
        }
    }
}
