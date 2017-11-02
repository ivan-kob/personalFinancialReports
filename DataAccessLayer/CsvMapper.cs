using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public static class CsvMapper
    {
        public static List<T> GetListFromStream<T>(StreamReader stream)
        {
            if (stream == null) throw new ArgumentException("Stream argument cannot be null");

            List<T> list = new List<T>();

            using (stream)
            {
                List<string> columnNamesList = new List<string>();

                if (stream.EndOfStream)
                    throw new EndOfStreamException("We reached the end of the stream without processing it");
                else
                {
                    columnNamesList = stream.ReadLine()
                        .Replace("\"",string.Empty)
                        .Split(',')
                        .ToList();
                }

                while (!stream.EndOfStream){

                    string[] rowValues = stream
                        .ReadLine()
                        .Replace("\"",string.Empty)
                        .Split(',');

                    T genericObject = Activator.CreateInstance<T>();
                    PropertyInfo[] genericObjectProperties = genericObject.GetType().GetProperties();

                    foreach (PropertyInfo property in genericObjectProperties)
                    {
                        
                        if (columnNamesList.Contains(property.Name))
                        {
                            int propertyIndex = columnNamesList.IndexOf(property.Name);
                            string rowValueBeforeConvert = rowValues[propertyIndex];
                            object rowValueAfterConvert = null;

                            if (!string.IsNullOrEmpty(rowValueBeforeConvert))
                            {
                                try
                                {
                                    rowValueAfterConvert = Convert.ChangeType(rowValues[propertyIndex], property.PropertyType);
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
    }
}
