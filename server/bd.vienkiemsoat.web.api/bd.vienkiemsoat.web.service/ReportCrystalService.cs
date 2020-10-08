using bd.vienkiemsoat.web.data;
using bd.vienkiemsoat.web.service.Interfaces;
using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Shared;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace bd.vienkiemsoat.web.service
{
    public class ReportCrystalService : IReportService
    {
        public byte[] ExportExcel(string fileName, Dictionary<string, object> dataset, Dictionary<string, string> parameters = null)
        {
            throw new System.Exception();
        }

        public byte[] ExportPDF(string fileName, Dictionary<string, object> dataset, Dictionary<string, object> parameters)
        {



            ReportDocument doc = new ReportDocument();
            doc.Load(fileName);
            doc.SetDatabaseLogon("vks22088_vienkiemsat", "Vks@123!");
            parameters.ToList().ForEach(x => doc.SetParameterValue(x.Key, x.Value));
            doc.ExportToDisk(ExportFormatType.PortableDocFormat, @"D:\thanh.pdf");
            var stream = ReadFully(doc.ExportToStream(ExportFormatType.PortableDocFormat));
            return stream;
        }

        public static byte[] ReadFully(Stream input)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                input.CopyTo(ms);
                return ms.ToArray();
            }
        }
    }
}
