using System;
using System.Linq;
using System.Reflection;

namespace CustomerWeb.Helpers
{
    internal class CsvFormatter<T> : ICsvFormatter<T>
    {
        private string delimiter;
        private PropertyInfo[] properties;

        public CsvFormatter(string delimiter)
        {
            this.delimiter = delimiter;
            this.properties = typeof(T).GetProperties();
        }

        public string FormatItem(T item)
        {
            return string.Join(this.delimiter, this.properties.Select(prop => prop.GetValue(item)));
        }

        public string GetHeader()
        {
            return string.Join(this.delimiter, typeof(T).GetProperties().Select(prop => prop.Name));
        }
    }
}