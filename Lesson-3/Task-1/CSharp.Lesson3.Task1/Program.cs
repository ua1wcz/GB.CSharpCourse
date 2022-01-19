using System;

namespace CSharp.Lesson3.Task1
{
    class Program
    {
        static void Main()
        {
            var offset = "\t";
            var array = new int[6, 6];
            var rows = array.GetUpperBound(0) + 1;
            var columns = array.Length / rows;

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    if (i < j)
                    {
                        array[i, j] = 0;
                    } 
                    else if (i > j)
                    {
                        array[i, j] = 2;
                    }
                    else
                    {
                        array[i, j] = 1;
                    }

                    Console.Write($"{array[i, j]} {offset}");
                }
                Console.WriteLine();
            }
        }
    }
}
