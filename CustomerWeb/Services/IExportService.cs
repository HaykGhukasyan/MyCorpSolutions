using System.Collections.Generic;
using System.IO;

namespace CustomerWeb.Services
{
    internal interface IExportService<T>
    {
        Stream GetExportStream(IEnumerable<T> items);
    }
}