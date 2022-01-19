using System;
using System.Globalization;
using System.Linq;

namespace CSharp.Lesson2.Task2
{
    class Program
    {
        static void Main()
        {
            Console.Clear();
            Console.WriteLine("Choose an option to check month selection:");
            Console.WriteLine("1) Find using System.Globalization");
            Console.WriteLine("2) Find using custom enum");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    Example1();
                    break;
                case "2":
                    Example2();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Incorrect value. Please, try again");
                    return;
            }
        }

        private static void Example1()
        {
            var dateTimeFormat = new DateTimeFormatInfo();
            var minMonthNumber = DateTime.MinValue.Month;
            var maxMonthNumber = DateTime.MaxValue.Month;

            ExampleWithAction(minMonthNumber, maxMonthNumber, (action) => dateTimeFormat.GetMonthName(action));
        }

        private static void Example2()
        {
            var monthValue = Enum.GetValues(typeof(Month)).Cast<int>();
            var minMonthNumber = monthValue.Min();
            var maxMonthNumber = monthValue.Max();

            ExampleWithAction(minMonthNumber, maxMonthNumber, (action) => ((Month)action).ToString());
        }

        private static void ExampleWithAction(int minMonthNumber, int maxMonthNumber, Func<int, string> action)
        {
            do
            {
                try
                {
                    Console.Write("Enter month number and press <Enter>: ");
                    var number = Console.ReadLine();
                    var convertedNumber = Convert.ToInt32(number);
                    if (minMonthNumber > convertedNumber | convertedNumber > maxMonthNumber)
                    {
                        throw new FormatException($"Month number cannot be " +
                            $"lower than {minMonthNumber} and " +
                            $"larger than {maxMonthNumber}");
                    }

                    Console.WriteLine($"Month: {action(convertedNumber)}\n");
                    Console.WriteLine("Press <Enter> to continue or any key to exit\n");
                    var enteredKey = Console.ReadKey();
                    if (enteredKey.Key == ConsoleKey.Enter)
                    {
                        continue;
                    }
                    Console.WriteLine("Exit");
                    return;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Enter value error: {exception.Message}");
                    Console.WriteLine("Please, try again\n");
                }
            } while (true);
        }

        private enum Month
        {
            January = 1,
            February,
            March,
            April,
            May,
            June,
            July,
            August,
            September,
            October,
            November,
            December
        }
    }
}
