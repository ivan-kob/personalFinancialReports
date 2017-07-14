﻿using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Models.Browser;

namespace PersonalFinancialReports
{
    class ConsoleView
    {
        static void Main(string[] args)
        {
            using (Browser navigator = new Browser(Browsers.EXPLORER))
            {
                navigator.GoToUrl("https://bancanet.banamex.com/");
                navigator.WaitSeconds(5);
                navigator.SetTextToElement("username1", "141924255");
                navigator.SubmitButton("ENTRAR");
                navigator.WaitSeconds(5);
            }
        }
    }
}
