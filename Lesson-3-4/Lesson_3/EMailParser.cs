using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lesson_3
{
	/*
	3. * Работа со строками.
	Дан текстовый файл, содержащий ФИО и e-mail адрес.
	Разделителем между ФИО и адресом электронной почты является символ &:

	Кучма Андрей Витальевич & Kuchma@mail.ru
	Мизинцев Павел Николаевич & Pasha@mail.ru
	

	Сформировать новый файл, содержащий список адресов электронной почты.

	Предусмотреть метод, выделяющий из строки адрес почты.
	Методу в качестве параметра передается символьная строка s,	
	e-mail возвращается в той же строке s: public void SearchMail (ref string s). 
	*/
	public class EMailParser
	{
		public List<FullNameAndEMail> ParseFullNameAndEMailFromFile(string fileName)
		{
			var list = new List<FullNameAndEMail>();
			using (StreamReader sr = new StreamReader(fileName))
			{
				string line = string.Empty;
				while (!sr.EndOfStream)
				{
					line = sr.ReadLine();
					if (line.Contains("&"))
					{
						var array = line.Split('&');
						string fullName = array[0].Trim();
						string email = array[1].Trim();
						SearchMail(ref email);

						list.Add(new FullNameAndEMail(fullName, email));
					}
				}
			}

			return list;
		}

		public void WriteEmailsToFile(string fileName, List<FullNameAndEMail> mails)
		{
			using var sw = new StreamWriter(File.Create(fileName));
			foreach (var mail in mails)
				sw.WriteLine(mail.Email);
		}

		public void ParseEmailFromFileAndWriteNewFile(string fileNameInput, string fileNameOutput)
		{
			var list = ParseFullNameAndEMailFromFile(fileNameInput);
			WriteEmailsToFile(fileNameOutput, list);
		}

		public void SearchMail(ref string s)
		{
			var regex = new Regex(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,64}");
			if(regex.IsMatch(s))
				s = regex.Match(s).Value;
		}
	}

	public class FullNameAndEMail
	{
		public override string ToString() => $"{FullName} ({Email})";

		public string FullName { get; set; }
		public string Email { get; set; }

		public FullNameAndEMail(string fullName, string email)
		{
			FullName = fullName;
			Email = email;
		}
	}
}
