using System;

namespace CSharp.Lesson4.Task4
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter a number to calculate the Fibonacci positive number: ");
            try
            {
                var enteredNumber = ulong.Parse(Console.ReadLine());
                Console.WriteLine($"Fibbonacci number: {FibbonacciPositive(enteredNumber)}");
            }
            catch (Exception)
            {

                throw;
            }
        }

        private static ulong FibbonacciPositive(ulong number)
        {
            if (number == 0 | number == 1)
            {
                return number;
            }

            return FibbonacciPositive(number - 1) + FibbonacciPositive(number - 2);
        }
    }
}
