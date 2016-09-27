using System;
using System.Collections.Generic;
using CustomerWeb.Helpers;
using CustomerWeb.Models;
using CustomerWeb.Services;
using System.IO;
using System.Text;

namespace CustomerWeb.Services
{
    internal class CsvExportService<T> : IExportService<T>
    {
        private ICsvFormatter<T> csvFormatter;

        public CsvExportService(ICsvFormatter<T> csvFormatter)
        {
            this.csvFormatter = csvFormatter;
        }

        public Stream GetExportStream(IEnumerable<T> items)
        {
            var fileName = Path.GetTempFileName();
            var stream = File.Open(fileName, FileMode.Open);

                using (var streamWriter = new StreamWriter(stream, Encoding.UTF8, 512, true))
                {
                    streamWriter.WriteLine(this.csvFormatter.GetHeader());
                    foreach (var item in items)
                    {
                        streamWriter.WriteLine(this.csvFormatter.FormatItem(item));
                    }
                }

            stream.Position = 0;
            return stream;
        }
    }
}