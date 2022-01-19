using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace CSharp.Lesson2.Task4
{
    class Program
    {
        static void Main()
        {
            if (GetSeasonByNumber(SelectMonth()) == Season.Winter & AverageTemperature() > 0)
            {
                Console.WriteLine("Дождливая зима");
            }

        }

        private static int SelectMonth()
        {
            var dateTimeFormat = new DateTimeFormatInfo();
            var minMonthNumber = DateTime.MinValue.Month;
            var maxMonthNumber = DateTime.MaxValue.Month;

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

                    Console.WriteLine($"Month: {dateTimeFormat.GetMonthName(convertedNumber)}\n");
                    return convertedNumber;
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Enter value error: {exception.Message}");
                    Console.WriteLine("Please, try again\n");
                }
            } while (true);
        }

        private static int AverageTemperature()
        {
            int тemrepature;
            var temperatureList = new List<int>();
            do
            {
                try
                {
                    Console.Write("Enter temperature and press <Enter>: ");
                    string consoleInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(consoleInput))
                    {
                        Console.WriteLine("Error: Entered value is empty.\n");
                        Console.WriteLine("Press <Enter> to retry or any key to exit");
                        var readResult = Console.ReadKey();
                        if (readResult.Key == ConsoleKey.Enter)
                        {
                            continue;
                        }
                        else
                        {
                            if (temperatureList.Count > 0)
                            {
                                break;
                            }
                        }
                    }

                    тemrepature = Convert.ToInt16(consoleInput);
                    temperatureList.Add(тemrepature);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Input error: {exception.Message}");
                }
            } while (true);

            var averageTemperature = Convert.ToInt32(temperatureList.Average());
            Console.WriteLine($"Average temperature: {averageTemperature}\n");

            return averageTemperature;
        }

        private static Season GetSeasonByNumber(int monthNumber)
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
                    break;
            }

            return Season.Empty;
        }

        private enum Season
        {
            Empty = 0,
            Winter,
            Spring,
            Summer,
            Autumn
        }
    }
}
