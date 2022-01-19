using BankAccount;
using System;

namespace BankAccount2
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAcc2 ba1 = new BankAcc2(100, BankAcc.TypeBankAccount.Deb);
            //ba1.balance = 100;
            //ba1.typebankaccount = BankAcc.TypeBankAccount.Deb;
            Console.WriteLine("Данные счета1:");
            Console.WriteLine(ba1.ToString());
            Console.WriteLine($"\"H1 \" + {ba1.numaccount} ");
            BankAcc2 ba4 = new BankAcc2(110, BankAcc.TypeBankAccount.Curr);
            //ba2.balance = 110;
            //ba2.typebankaccount = BankAccount.BankAcc.TypeBankAccount.Deb;
            Console.WriteLine("Данные счета2:");
            Console.WriteLine(ba4.ToString());

            Console.WriteLine($"\"H2 \" + {ba1.numaccount} + \" 2 \" + {ba4.numaccount}");
            Console.WriteLine();

            Console.WriteLine($"ba1 == ba2 : {ba1 == ba4}");
            Console.WriteLine($"ba1 != ba2 : {ba1 != ba4}");
            Console.WriteLine($"ba1.Equals(ba2) : {ba1.Equals(ba4)} + \" 1 \" + {ba1.numaccount} + \" 2 \" + {ba4.numaccount}");
            Console.WriteLine($"ba1.GetHashCode : {ba1.GetHashCode()}");
            Console.WriteLine($"ba2.GetHashCode : {ba4.GetHashCode()}");


        }
    }
}
