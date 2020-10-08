using System.Collections.Generic;

namespace bd.vienkiemsoat.web.service.Interfaces
{
    public interface IReportService
    {
        byte[] ExportExcel(string fileName, Dictionary<string, object> dataset, Dictionary<string, string> parameters = null);

        byte[] ExportPDF(string fileName, Dictionary<string, object> dataset, Dictionary<string, string> parameters = null);


    }
}
