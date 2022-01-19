using CSharp.Lesson8.Task1.Properties;
using System;

namespace CSharp.Lesson8.Task1
{
    class Program
    {
        static void Main()
        {
            try
            {
                if (string.IsNullOrEmpty(Settings.Default.Name)
                || string.IsNullOrEmpty(Settings.Default.Age)
                || string.IsNullOrEmpty(Settings.Default.Occupation))
                {
                    Console.Write("Введите имя:");
                    Settings.Default.Name = Console.ReadLine();
                    Console.Write("Введите возраст:");
                    Settings.Default.Age = Console.ReadLine();
                    Console.Write("Введите род занятий:");
                    Settings.Default.Occupation = Console.ReadLine();
                    Settings.Default.Save();
                    Console.WriteLine("Entered information saved successfully");
                }
                else
                {
                    string user = Settings.Default.Name;
                    string age = Settings.Default.Age;
                    string occupation = Settings.Default.Occupation;
                    Console.WriteLine("Loading previously saved information...");
                    Console.WriteLine($"[Name]:{user}, [Age]:{age}, [Occupation]:{occupation}");
                }            
            }
            catch (Exception exception)
            {
                Console.WriteLine($"ERROR: {exception.Message}");
            }
        }
    }
}
