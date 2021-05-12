using System;
using System.Collections.Generic;
using System.IO;

namespace CSharp.Lesson5.Task3
{
    class Program
    {
        static void Main()
        {
            int number;
            var numbersList = new List<int>();
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

                    number = Convert.ToInt16(consoleInput);
                    if (number < 0 | number > 255)
                    {
                        throw new InvalidOperationException("Number should be between 0 and 255.");
                    }

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
                using (var writer = new BinaryWriter(File.Open(filePath, FileMode.Create)))
                {
                    foreach (var selectedNumber in numbersList)
                    {
                        writer.Write(selectedNumber);
                    }
                }
                Console.Write($"All values saved to file: {filePath}");
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}");
                return;
            }
            
        }
    }
}
