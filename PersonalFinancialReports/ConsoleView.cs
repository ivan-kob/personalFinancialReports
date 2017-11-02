using BusinessLogicLayer;
using Models;
using System;
using System.Collections.Generic;
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
            Thread.CurrentThread.CurrentCulture = new CultureInfo("es-mx");
            CsvReader.ReadFile();
        }
    }
}
