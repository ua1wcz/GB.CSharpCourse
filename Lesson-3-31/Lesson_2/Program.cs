using System;

namespace Lesson_2
{
	class Program
	{
		static void Main(string[] args)
		{
			var bankAccount = new BankAccount(AccountType.Current, 250); 
			bankAccount.AccType = AccountType.Payments;
			bankAccount.AddBalance(100);
			
			if(!bankAccount.PullBalance(500))
				Console.WriteLine("Недостаточно средств!");

			Console.WriteLine(bankAccount.Print());
		}
	}
}
