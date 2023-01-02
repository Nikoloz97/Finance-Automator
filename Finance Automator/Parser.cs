using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Finance_Automator
{
    public class Parser
    {
        public static void letsParse()
        {
            // Instantiate models
            Expenses expenses = new Expenses();
            Revenue revenue = new Revenue();

            // Parsing transactions file... 
            Console.
            string filename = @"C:\Users\nickg\source\repos\Finance Automator\Transactions_02-01-2023.csv";
            decimal total = 0;
            using (StreamReader sr = new StreamReader(filename))
            {
                try
                {

                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] itemArray = line.Split(',');
                        decimal lineValue;
                        if (itemArray[1].Contains("WM"))
                        {
                            Decimal.TryParse(itemArray[3], out lineValue);
                            expenses.Groceries += lineValue;
                        }
                    }
                }
                catch (Exception)
                {

                    Console.WriteLine("Oops, something went wrong processing income file");
                }
            }
            Console.WriteLine(expenses.Groceries);
        }
    }
}
