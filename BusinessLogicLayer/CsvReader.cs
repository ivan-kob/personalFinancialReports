using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using DataAccessLayer;
using Models;

namespace BusinessLogicLayer
{
    public static class CsvReader
    {
        private static string CsvFolder => ConfigurationManager.AppSettings["CSVFolder"];
        private static bool ReleaseMode => Convert.ToBoolean(ConfigurationManager.AppSettings["ReleaseMode"]);

        public static void ReadFile()
        {
            List<Transaction> genericList = CsvMapper.GetListFromStream<Transaction>(new StreamReader(GetCsvFileLocation()));
            
        }

        private static string GetCsvFileLocation()
        {
            if(ReleaseMode)
                return $@"{CsvFolder}\test.csv";
            else
                return @"C:\Users\Edwin Lap\Documents\Personal\PersonalWork\personalFinancialReports\csvFolder\test.csv";
        }
    }
}
