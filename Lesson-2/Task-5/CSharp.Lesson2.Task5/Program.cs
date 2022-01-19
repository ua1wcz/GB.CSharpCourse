using System;

namespace CSharp.Lesson2.Task5
{
    class Program
    {
        static void Main()
        {
            var office1 = WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday | WeekDays.Friday;
            Console.WriteLine($"Office №1: {office1}");

            var office2 = WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday | WeekDays.Friday | WeekDays.Saturday | WeekDays.Sunday;
            Console.WriteLine($"Office №2: {office2}");

            var office3 = WeekDays.Thursday | WeekDays.Friday | WeekDays.Saturday | WeekDays.Sunday;
            Console.WriteLine($"Office №3: {office3}");

            var office4 = WeekDays.Monday | WeekDays.Tuesday | WeekDays.Wednesday | WeekDays.Thursday;
            Console.WriteLine($"Office №4: {office4}");
        }

        [Flags]
        private enum WeekDays
        {
            Monday = 0b_0000001,
            Tuesday = 0b_0000010,
            Wednesday = 0b_0000100,
            Thursday = 0b_0001000,
            Friday = 0b_0010000,
            Saturday = 0b_0100000,
            Sunday = 0b_1000000,
        }
    }
}
