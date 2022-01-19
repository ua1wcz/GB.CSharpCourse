using System;

namespace CSharp.Lesson4.Task1
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine(GetFullName("Ivanov", "Ivan", "Ivanovich"));
            Console.WriteLine(GetFullName("Petrov", "Petr", "Petrovich"));
            Console.WriteLine(GetFullName("Vasilyev", "Vasiliy", "Vasilyevich"));
            Console.WriteLine(GetFullName("Sidorov", "Sidor", "Sidorovich"));
        }

        private static string GetFullName(string firstName, string lastName, string patronymic)
        {
            return $"{lastName} {firstName} {patronymic}";
        }
    }
}
