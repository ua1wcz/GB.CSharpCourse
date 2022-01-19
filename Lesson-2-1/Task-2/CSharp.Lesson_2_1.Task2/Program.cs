using System;

namespace CSharp.Lesson_2_1.Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(FibbonaciResult());
        }

        private static string FibbonaciResult()
        {
            Console.Write("Введите число: ");

            string result = string.Empty;
            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                int a = 0, b = 1, c = 0;
                for (int i = 2; i < number; i++)
                {
                    c = a + b;
                    result += $" {c}";
                    a = b;
                    b = c;
                }
            }

            return result;
        }
    }
}
