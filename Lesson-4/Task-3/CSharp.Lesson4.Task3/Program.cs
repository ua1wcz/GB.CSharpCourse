using System;

namespace CSharp.Lesson4.Task3
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter month number and press <Enter>:");
            var enteredValue = Console.ReadLine();
            try
            {
                var result = GetSeason(int.Parse(enteredValue));
                if (result != Season.Unknown)
                {
                    Console.WriteLine(result);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}. Please, try again.");
            }
            
        }

        private static Season GetSeason(int monthNumber)
        {
            switch (monthNumber)
            {
                case 12:
                case 1:
                case 2:
                    return Season.Winter;
                case 3:
                case 4:
                case 5:
                    return Season.Spring;
                case 6:
                case 7:
                case 8:
                    return Season.Summer;
                case 9:
                case 10:
                case 11:
                    return Season.Autumn;
                default:
                    Console.WriteLine("Incorrect month number!");
                    return Season.Unknown;
            }
        }

        private enum Season
        {
            Unknown = 0,
            Winter,
            Spring,
            Summer,
            Autumn
        }
    }
}
