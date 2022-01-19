using System;

namespace CSharp.Lesson4.Task2
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Enter multiple numbers, spaces separated and press <Enter>");
            var numbers = Console.ReadLine().Split(" ");
            try
            {
                Console.WriteLine(GetSumm(numbers));
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}. Please, try again.");
                return;
            }
        }

        private static int GetSumm(params string[] numbers)
        {
            int sum = 0;
            for (int i = 0; i < numbers.Length; i++)
            {
                sum += int.Parse(numbers[i]);
            }

            return sum;
        }
    }
}
