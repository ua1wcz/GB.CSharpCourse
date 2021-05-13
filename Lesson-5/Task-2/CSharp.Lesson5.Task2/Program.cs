using System;
using System.IO;

namespace CSharp.Lesson5.Task2
{
    class Program
    {
        static void Main()
        {
            const string fileName = "startup.txt";
            var dateTime = DateTime.Now.ToString("dd/mm/yyyy HH:mm:ss");

            File.AppendAllText(fileName, dateTime + Environment.NewLine);
            Console.WriteLine($"Date and time added to {fileName}");
        }
    }
}
