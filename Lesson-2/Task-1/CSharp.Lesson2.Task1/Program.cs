using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharp.Lesson2.Task1
{
    class Program
    {
        static void Main()
        {
            int тemrepature;
            var temperatureList = new List<int>();
            Console.WriteLine("The programm supports average temperature.");
            Console.WriteLine("Supports possibility to enter multiple variables");
            Console.WriteLine("=======================================");
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

                            return;
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

            var averageTemperature = temperatureList.Average();
            Console.Write($"Average temperature: {averageTemperature}");
        }
    }
}
