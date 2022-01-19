using System;

namespace Lesson_3
{
	public enum AccountType
	{
		Current,
		Credit,
		Deposit,
		Payments
	};

	/*
	1. В класс банковский счет, созданный в упражнениях, добавить метод, который переводит деньги с одного счета на другой.
	У метода два параметра: ссылка на объект класса банковский счет откуда снимаются деньги, второй параметр – сумма.
	
	2. Реализовать метод, который в качестве входного параметра принимает строку string,
	возвращает строку типа string, буквы в которой идут в обратном порядке.
	Протестировать метод.
	
	3. * Работа со строками. Дан текстовый файл, содержащий ФИО и e-mail адрес.
	Разделителем между ФИО и адресом электронной почты является символ &:
	Кучма Андрей Витальевич & Kuchma@mail.ru
	Мизинцев Павел Николаевич & Pasha@mail.ru
	
	Сформировать новый файл, содержащий список адресов электронной почты.
	Предусмотреть метод, выделяющий из строки адрес почты.
	Методу в качестве параметра передается символьная строка s,
	e-mail возвращается в той же строке s: public void SearchMail (ref string s). 
	*/
	public class BankAccount
	{
		public override string ToString() => $"[{ID}] ({AccType}) {Balance}";

		static decimal LastID = 0;

		decimal _id;
		decimal _balance;
		AccountType _type;

		public decimal ID => _id;
		public decimal Balance
		{
			get => _balance;
			set => _balance = value;
		}
		public AccountType AccType
		{
			get => _type;
			set => _type = value;
		}

		public BankAccount()
		{
			_id = NewID();
		}
		public BankAccount(decimal balance)
		{
			_id = NewID();
			_balance = balance;
		}
		public BankAccount(AccountType type)
		{
			_id = NewID();
			_type = type;
		}
		public BankAccount(AccountType type, decimal balance)
		{
			_id = NewID();
			_type = type;
			_balance = balance;
		}

		public string Print()
		{
			return $"Account: {ID}{Environment.NewLine}Acoount type: {AccType}{Environment.NewLine}Balance: {Balance}";
		}

		private decimal NewID()
		{
			return ++LastID;
		}

		public void AddBalance(decimal money)
		{
			Balance += money;
		}
		public bool PullBalance(decimal money)
		{
			if (Balance >= money)
			{
				Balance -= money;
				return true;
			}
			return false;
		}

		public bool MoneyTransfer(BankAccount account, decimal money)
		{
			if(account != null && account.PullBalance(money))
			{
				AddBalance(money);
				return true;
			}

			return false;
		}
	}
}
