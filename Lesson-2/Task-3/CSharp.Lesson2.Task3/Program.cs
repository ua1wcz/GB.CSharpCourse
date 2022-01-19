using System;

namespace CSharp.Lesson2.Task3
{
    class Program
    {
        static void Main()
        {
            // Operator information
            int azsNumber = 0035;
            int cassNumber = 0004;
            int operatorNumber = 0354;
            int billNumber = 0924;

            // Taxes information
            long inn = 7700000000;
            long eklzNumber = 3297258661;
            long fiscalRegim = 82143979;

            // Operation information
            double goodRate = 19.50;
            double goodCount = 70.000;
            double amount = goodRate * goodCount;
            double cash = 1500.00;
            double change = cash - amount;
            string currency = "Рубль России";

            // Goods information
            string good = "ДТ";

            // DateTime
            var dateTimeNow = DateTime.Now;
            string operationTime = dateTimeNow.ToString("hh:mm:ss");
            string operationDate = dateTimeNow.ToString("dd/mm/yyyy");

            // Template
            string billTemplate = $@"   НОВЫЙ ЧЕК         


АЗС {azsNumber} КАССА {cassNumber} ОПЕРАТОР {operatorNumber}
ИНН ОРГ. -ПРОДАВЦА {inn}
{good}      {operationTime}     {amount}
RBL      {goodRate}X{goodCount}
--------------------------------
ИТОГО                   {amount}
--------------------------------
{currency}            {amount}
Наличными               {cash}
Сдача                   {change}
ЭКЛЗ    {eklzNumber}
        СПАСИБО
        ЗА ПОКУПКУ
ЧЕК {billNumber}    {operationDate} {operationTime}
ФИСКАЛЬНЫЙ РЕЖИМ    {fiscalRegim}";

            Console.WriteLine(billTemplate);
        }
    }
}
