using CsvHelper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ReflectionHometask
{
    public static class Serializer
    {
        public static string SerializeObjectToString(object obj)
        {
            StringBuilder stringBuilder = new();

            Type type = obj.GetType();
            PropertyInfo[] fields = type.GetProperties();

            foreach (var field in fields)
            {
                stringBuilder.AppendLine($"{field.Name}: {field.GetValue(obj)}");
            }

            return stringBuilder.ToString();
        }

        public static void DeserializeCsv<T>(string filePath) where T : new()
        {
            List<Dictionary<string, string>> csvValues = ParseCsvFile(filePath);

            T obj = new();

            foreach (var property in typeof(T).GetProperties())
            {
                if (csvValues[0].TryGetValue(property.Name, out string value))
                {
                    Type propertyType = property.PropertyType;
                    object convertedValue = Convert.ChangeType(value, propertyType);
                    property.SetValue(obj, convertedValue);
                }
            }
        }

        private static List<Dictionary<string, string>> ParseCsvFile(string filePath)
        {
            List<Dictionary<string, string>> csvValues = new List<Dictionary<string, string>>();

            using (StreamReader reader = new StreamReader(filePath))
            {
                string headerLine = reader.ReadLine();
                string[] headers = headerLine.Split(',');

                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    string[] data = line.Split(',');

                    Dictionary<string, string> rowData = new Dictionary<string, string>();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        rowData[headers[i]] = data[i];
                    }

                    csvValues.Add(rowData);
                }
            }

            return csvValues;
        }

    }
}
