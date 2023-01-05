using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Spreadsheet;
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
            XLWorkbook workbook= new XLWorkbook();
            Expenses expenses = new Expenses();
            Revenue revenue = new Revenue();


            // Prompt for user... 
            /*Console.WriteLine("Enter a filepath please: ");
            string filename = Console.ReadLine();*/

            // Parsing transactions file... 
            string filename = @"C:\Users\nickg\source\repos\Finance Automator\Transactions_02-01-2023.csv";

            using (StreamReader sr = new StreamReader(filename))
            {
                try
                {
   
                    while (!sr.EndOfStream)
                    {
                        int lineCounter = 0;
                        lineCounter++;
                        // start at the second line (first line = just titles) 
                        if (lineCounter == 1)
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
                    // Tried to create a workbook (doesn't work...) 
                    // https://www.youtube.com/watch?v=en0lA0foKYY&ab_channel=ASP.NETMVC
/*
                    var ws = workbook.Worksheets.Add("Sheet1");
                    ws.Cell("A1").Value = "Full Name";

                    workbook.SaveAs("GettingStarted.xlsx");*/
                    
                }
                catch (Exception)
                {

                    Console.WriteLine("Oops, something went wrong processing income file");
                }

                // Trying to create a file in MonthlyReports directory...

                string reportsDirectory = @"C:\Users\nickg\source\repos\Finance Automator\Finance Automator\MonthlyReports\";
                string Month = expenses.Month;
                string Filepath = Path.Combine(reportsDirectory, Month, ".xlsx");
                File.Create(Filepath);

                Console.WriteLine(expenses.Groceries);

            }

            
        }
    }
}
