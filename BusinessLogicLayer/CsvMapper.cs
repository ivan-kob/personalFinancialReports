﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer
{
    public static class CsvMapper
    {
        public static List<T> GetListFromStream<T>(StreamReader stream)
        {
            if (stream == null) throw new ArgumentNullException("Stream argument cannot be null");

            List<T> list = new List<T>();

            using (stream)
            {
                List<string> columnNamesList = GetColumnNames(stream);
                List<string> csvContentLines = GetCsvCsvContentLines(stream);

                foreach (string csvContentLine in csvContentLines)
                {
                    string[] csvContentLineSplited = csvContentLine.Split(',');
                    T genericObject = Activator.CreateInstance<T>();
                    PropertyInfo[] genericObjectProperties = genericObject.GetType().GetProperties();

                    foreach (PropertyInfo property in genericObjectProperties)
                    {

                        if (columnNamesList.Contains(property.Name))
                        {
                            int propertyIndex = columnNamesList.IndexOf(property.Name);
                            string rowValueBeforeConvert = csvContentLineSplited[propertyIndex];
                            object rowValueAfterConvert = null;

                            if (!string.IsNullOrEmpty(rowValueBeforeConvert))
                            {
                                try
                                {
                                    rowValueAfterConvert = Convert.ChangeType(csvContentLineSplited[propertyIndex], property.PropertyType);
                                }
                                catch (Exception ex)
                                {
                                    Console.WriteLine(ex);
                                }

                            }

                            property.SetValue(genericObject, rowValueAfterConvert);
                        }
                    }

                    list.Add(genericObject);
                }
            }

            return list;
        }

        
        //TODO Refactor these two methods, they are sharing the same base of code
        private static List<string> GetColumnNames(StreamReader stream)
        {
            int INITIAL_STREAM_POSITION = 0;
            if (stream == null)
                throw new ArgumentNullException("The stream is null");
            if (stream.EndOfStream)
                stream.BaseStream.Position = INITIAL_STREAM_POSITION;

            return stream.ReadLine().Replace("\"","").Split(',').ToList();
        }

        
        private static List<string> GetCsvCsvContentLines(StreamReader stream)
        {
            int INITIAL_STREAM_POSITION = 0;
            List<string> csvContentSeparatedByLine = new List<string>();
            if (stream == null)
                throw new ArgumentNullException("The stream is null");
            
            if (stream.EndOfStream)
                stream.BaseStream.Position = INITIAL_STREAM_POSITION;

            //Check after read the first line is end of stream, if so return the empty list
            stream.ReadLine();
            if (stream.EndOfStream)
                return csvContentSeparatedByLine;

            while (!stream.EndOfStream)
            {
                csvContentSeparatedByLine.Add(stream.ReadLine().Replace("\"", ""));
            }

            return csvContentSeparatedByLine;
        }
    }
}
