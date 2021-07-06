namespace CSharp.Lesson_2_1.Task3
{
    class Program
    {
        static void Main(string[] args)
        {
        }

		public static int StrangeSum(int[] inputArray)
		{
			int sum = 0;

			//	O(n)
			for (int i = 0; i < inputArray.Length; i++)             
			{
				//	O(n)
				for (int j = 0; j < inputArray.Length; j++)         
				{
					//	O(n)
					for (int k = 0; k < inputArray.Length; k++)     
					{
						int y = 0;

						if (j != 0)
						{
							y = k / j;
						}

						sum += inputArray[i] + i + k + j + y;
					}
				}
			}

			return sum;
		}

		// O(3n)
	}
}
