using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp.Lesson5.Task3
{
    class Program
    {
        static void Main()
        {
            byte number;
            var numbersList = new List<byte>();
            Console.WriteLine("The programm supports saving numbers to binary file.");
            Console.WriteLine("Supports possibility to enter multiple variables");
            Console.WriteLine("=======================================");
            do
            {
                try
                {
                    Console.Write("Enter number and press <Enter>: ");
                    string consoleInput = Console.ReadLine();
                    if (string.IsNullOrEmpty(consoleInput))
                    {
                        Console.WriteLine("Error: Entered value is empty.\n");
                        Console.WriteLine("Press <Enter> to retry or any key to Save file and Exit");
                        var readResult = Console.ReadKey();
                        if (readResult.Key == ConsoleKey.Enter)
                        {
                            continue;
                        }
                        else
                        {
                            if (numbersList.Count > 0)
                            {
                                break;
                            }

                            return;
                        }
                    }

                    number = Convert.ToByte(consoleInput);
                    numbersList.Add(number);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"Input error: {exception.Message}");
                }
            } while (true);

            var fileName = "Lesson5.Task3.dat";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), fileName);

            try
            {
                File.WriteAllBytes(filePath, numbersList.ToArray());
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}");
                return;
            }
        }
    }
}
