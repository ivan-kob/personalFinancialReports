using BusinessLogicLayer;
using Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Models.Browser;

namespace PersonalFinancialReports
{
    class ConsoleView
    {
        static void Main(string[] args)
        {
            //using (Browser navigator = new Browser(Browsers.CHROME))
            //{
            //    navigator.GoToUrl("https://bancanet.banamex.com/");
            //    navigator.WaitSeconds(5);
            //    navigator.SetTextToElement("username1", "141924255");
            //    navigator.SubmitButton("ENTRAR");
            //    navigator.WaitSeconds(5);
            //}
            Console.Write("1) Import CSV file to DB\n" +
                "2) Exit\n\n" +
                "Choose option: ");
            string optionChosen = Console.ReadLine();

            if(optionChosen == "1")
            {
                Thread.CurrentThread.CurrentCulture = new CultureInfo("es-mx");
                List<Transaction> csvContent = CsvReader.ReadFile<Transaction>();

                /*Create db connection*/
                using (SqlConnection dbConnection = new SqlConnection("Data Source=.;Initial Catalog=PersonalFinancialReportsDB;Integrated Security=SSPI;"))
                {
                    dbConnection.Open();

                    StringBuilder insertQuery = new StringBuilder("INSERT INTO dbo.[Transaction](AccountID, Date, Description, Debit, Credit, Balance) VALUES");

                    foreach (Transaction transaction in csvContent)
                    {
                        insertQuery.Append($"(1,'{transaction.Date.ToString("yyyy-MM-dd")}','{transaction.Description}',{transaction.Debit},{transaction.Credit},{transaction.Balance}),");
                    }

                    SqlCommand command = new SqlCommand(insertQuery.Remove(insertQuery.Length - 1, 1).ToString(), dbConnection);
                    command.ExecuteNonQuery();
                }

            }

        }

    }
}
