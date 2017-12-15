using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.IO;
using Models;

namespace BusinessLogicLayer
{
    /*
     * Change the name to CsvImporter
     * This class is intented to read a csv file, mapping it into app entities 
     * and store them into the database after add the account id(is the one who is asking for read the file)
     */
    public static class CsvReader
    {
        private static string CsvFolder => ConfigurationManager.AppSettings["CSVFolder"];
        private static bool ReleaseMode => Convert.ToBoolean(ConfigurationManager.AppSettings["ReleaseMode"]);

        public static List<T> ReadFile<T>()
        {
            string fileLocation = GetCsvFileLocation();
            StreamReader fileStream = GetFileStream(fileLocation);
            return CsvMapper.GetListFromStream<T>(fileStream);
            /*For testing purposes*/
            //genericList.ForEach(x => Console.WriteLine($"Date: {x.Date}, Desc: {x.Description}, Credit: {x.Credit}, Balance: {x.Balance}"));
            //Console.Read();
            
        }

        private static string GetCsvFileLocation()
        {
            if(ReleaseMode)
                return $@"{CsvFolder}\test.csv";
            else
                return @"C:\Users\Edwin Lap\Documents\Personal\PersonalWork\personalFinancialReports\csvFolder\test.csv";
        }

        private static StreamReader GetFileStream(string fileLocation) {

            return new StreamReader(fileLocation);

        }
    }
}
