using Lesson_4.BuildCreator;
using System;
using System.Text;

namespace Lesson_4
{
	class Program
	{
		static void Main(string[] args)
		{
			var random = new Random();
			for (int i = 0; i < 10; i++)
				Creator.CreateBuild();

			foreach (Build build in Creator.Builds.Values)
				Console.WriteLine($"Build ID: {build.GetID()}");

			Console.WriteLine();
			var index = random.Next(1, 10);
			Console.WriteLine($"Delete build ID: {index}");
			Creator.DeleteBuild(index);

			foreach (Build build in Creator.Builds.Values)
				Console.WriteLine($"Build ID: {build.GetID()}");
		}
	}
}
