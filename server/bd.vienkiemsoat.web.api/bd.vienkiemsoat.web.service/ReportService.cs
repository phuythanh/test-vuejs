using bd.vienkiemsoat.web.service.Interfaces;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.Linq;

namespace bd.vienkiemsoat.web.service
{
    public class ReportService: IReportService
    {
        public byte[] ExportExcel(string fileName, Dictionary<string, object> dataset, Dictionary<string, string> parameters = null)
        {
            // Variables
            string mimeType = string.Empty;
            string encoding = string.Empty;
            string extension = string.Empty;

            ReportViewer viewer = new ReportViewer
            {
                ProcessingMode = ProcessingMode.Local
            };
            viewer.LocalReport.ReportPath = fileName;

            foreach (var item in dataset)
            {
                viewer.LocalReport.DataSources.Add(new ReportDataSource(item.Key, item.Value));
            }
            viewer.LocalReport.SetParameters(parameters.Select(x => new ReportParameter(x.Key, x.Value)));

            byte[] bytes = viewer.LocalReport.Render("EXCEL", null, out mimeType, out encoding, out extension, out string[] streamIds, out Warning[] warnings);
            return bytes;
        }

        public byte[] ExportPDF(string fileName, Dictionary<string, object> dataset, Dictionary<string, string> parameters)
        {
            throw new System.NotImplementedException();
        }
    }
}
