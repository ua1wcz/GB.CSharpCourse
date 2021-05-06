using System;

namespace CSharp.Lesson3.Task2
{
    class Program
    {
        private static string[,] _phonesArray = new string[5, 2];

        static void Main()
        {
            // Default values
            _phonesArray[0, 0] = "John Doe";
            _phonesArray[0, 1] = "8 800 555 35 35";

            WelcomeScreen();
        }

        private static void WelcomeScreen()
        {
            Console.WriteLine("Phone Book\n");
            Console.WriteLine("1) Print all records");
            Console.WriteLine("2) Add record");
            Console.WriteLine("3) Delete record");
            Console.WriteLine("4) Exit");
            Console.Write("\r\nSelect an option: ");

            switch (Console.ReadLine())
            {
                case "1":
                    PrintRecords();
                    WelcomeScreen();
                    break;
                case "2":
                    AddRecord();
                    PrintRecords();
                    WelcomeScreen();
                    break;
                case "3":
                    PrintRecords();
                    DeleteRecord();
                    PrintRecords();
                    WelcomeScreen();
                    return;
                case "4":
                    return;
                default:
                    Console.WriteLine("Incorrect value. Please, try again");
                    return;
            }
        }

        private static void PrintRecords()
        {
            var offset = "\t";
            var rows = _phonesArray.GetUpperBound(0) + 1;
            var columns = _phonesArray.Length / rows;

            Console.WriteLine("All entries:");
            for (int i = 0; i < rows; i++)
            {
                Console.Write($"{i + 1} {offset}");
                for (int j = 0; j < columns; j++)
                {
                    Console.Write($"{_phonesArray[i, j]} {offset}");
                }
                Console.WriteLine();
            }
        }

        private static void AddRecord()
        {
            try
            {
                var name = GetAndCheckValue("\rEnter Name: ");
                var phone = GetAndCheckValue("\rEnter Email\\Phone number: ");

                int index = 0;
                for (int i = 0; i < _phonesArray.GetLength(0); i++)
                {
                    if (_phonesArray[i, 0] == null)
                    {
                        index = i;
                        break;
                    }
                }

                _phonesArray[index, 0] = name;
                _phonesArray[index, 1] = phone;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Input error: {exception.Message}");
            }
        }

        private static void DeleteRecord()
        {
            try
            {
                var index = Convert.ToUInt32(GetAndCheckValue("\rEnter number of record to delete: ")) - 1;
                _phonesArray[index, 0] = null;
                _phonesArray[index, 1] = null;
            }
            catch (Exception exception)
            {
                Console.WriteLine($"Input error: {exception.Message}");
            }
        }

        private static string GetAndCheckValue(string welcomeMessage)
        {
            do
            {
                Console.Write(welcomeMessage);
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
                        break;
                    }
                }

                return consoleInput;                
            } while (true);

            return string.Empty;
        }
    }
}
