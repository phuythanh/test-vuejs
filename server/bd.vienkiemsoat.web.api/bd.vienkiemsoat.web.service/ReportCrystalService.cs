using bd.vienkiemsoat.web.data;
using bd.vienkiemsoat.web.service.Interfaces;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using Microsoft.Reporting.WebForms;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bd.vienkiemsoat.web.service
{
    public class ReportCrystalService : IReportService
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
            var data = new SOFTZ_UTDAUEntities1();
            ReportDocument doc = new ReportDocument();
            ExportOptions CrExportOptions;
            DiskFileDestinationOptions CrDiskFileDestinationOptions = new DiskFileDestinationOptions();
            PdfRtfWordFormatOptions CrFormatTypeOptions = new PdfRtfWordFormatOptions();
            CrDiskFileDestinationOptions.DiskFileName = fileName;
            var dataset1 = data.RP_NHAPXUAT_PHIEU(1,"","", null,null,"").ToList();
            doc.SetDataSource(dataset1);
            parameters.ToList().ForEach(x => doc.SetParameterValue(x.Key, x.Value));
            CrExportOptions = doc.ExportOptions;
            {
                CrExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                CrExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                CrExportOptions.DestinationOptions = CrDiskFileDestinationOptions;
                CrExportOptions.FormatOptions = CrFormatTypeOptions;
            }
            var stream = (MemoryStream)doc.ExportToStream(ExportFormatType.PortableDocFormat);
            return stream.ToArray(); 
        }
    }
}
