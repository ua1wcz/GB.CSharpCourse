using System;
using System.IO;

namespace CSharp.Lesson5.Task1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Enter any text:");
            var enteredValue = Console.ReadLine();

            if (!string.IsNullOrEmpty(enteredValue))
            {
                const string textFileName = "Lesson5.Task1.txt";
                var fileToAppendText = Path.Combine(Directory.GetCurrentDirectory(), textFileName);
                File.AppendAllText(fileToAppendText, enteredValue);
                Console.WriteLine($"Text was saved to: {fileToAppendText}");
            }
        }
    }
}
