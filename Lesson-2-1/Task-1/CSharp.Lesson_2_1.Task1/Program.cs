using System;

namespace CSharp.Lesson_2_1.Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckNumber());
        }

        private static string CheckNumber()
        {
            Console.Write("Введите число: ");

            int number;
            if (int.TryParse(Console.ReadLine(), out number))
            {
                int d = 0;
                int i = 2;

                while (i < number)
                {
                    if (number % i == 0)
                    {
                        d++;
                    }

                    i++;
                } 
                
                if (d == 0)
                {
                   return "Число простое!";
                }
                else
                {
                    return "Число составное!";
                }  
            }

            return "Данные не введены";
        }
    }
}
