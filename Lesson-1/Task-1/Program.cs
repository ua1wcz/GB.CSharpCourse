using System;

namespace CSharp.Lesson1.Task1
{
    class Program
    {
        static void Main()
        {
            Console.Write("Введите имя пользователя и нажмите Enter: ");
            var userName = Console.ReadLine();
            Console.WriteLine($"Привет, {userName}, сегодня {DateTime.Now}");
        }
    }
}
