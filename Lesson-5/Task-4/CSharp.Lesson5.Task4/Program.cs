using System;
using System.IO;

namespace Csharp.Lesson5.Task4
{
    class Program
    {
        private static readonly string fileName = "Lesson5.Task4.txt";

        static void Main()
        {
            WelcomeScreen();
        }

        private static void WelcomeScreen()
        {
            Console.WriteLine("Show folder contents\n");
            Console.WriteLine("1) In folder");
            Console.WriteLine("2) Recursively");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    ShowFolderContents(EnterValue());
                    WelcomeScreen();
                    break;
                case "2":
                    ShowRecursively(EnterValue());
                    WelcomeScreen();
                    break;
                case "3":
                    return;
                default:
                    Console.WriteLine("Incorrect value. Please, try again");
                    WelcomeScreen();
                    break;
            }
        }

        static string EnterValue()
        {
            Console.Write("Enter folder path: ");
            var value = Console.ReadLine();
            if (Directory.Exists(value))
            {
                return value;
            }

            return string.Empty;
        }

        static void ShowRecursively(string value)
        {
            try
            {
                foreach (var folder in Directory.GetDirectories(value))
                {
                    File.AppendAllText(fileName, $"Directory: {folder}" + Environment.NewLine);
                    foreach (var file in Directory.GetFiles(folder))
                    {
                        File.AppendAllText(fileName, $"File: {file}" + Environment.NewLine);
                    }
                    ShowRecursively(folder);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}");
                return;
            }
        }

        static void ShowFolderContents(string value)
        {
            try
            {
                foreach (var folder in Directory.GetDirectories(value))
                {
                    File.AppendAllText(fileName, $"Directory: {folder}" + Environment.NewLine);
                }

                foreach (var file in Directory.GetFiles(value))
                {
                    File.AppendAllText(fileName, $"File: {file}" + Environment.NewLine);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}");
                return;
            }
        }
    }
}
