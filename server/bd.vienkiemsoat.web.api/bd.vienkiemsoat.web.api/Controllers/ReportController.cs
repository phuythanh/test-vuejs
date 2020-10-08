using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Hosting;
using System.Web.Http;
using AutoMapper;
using bd.vienkiemsoat.web.api.ViewModel;
using bd.vienkiemsoat.web.data;
using bd.vienkiemsoat.web.Model.Models;
using bd.vienkiemsoat.web.service.Interfaces;

namespace bd.vienkiemsoat.web.api.Controllers
{
    public class ReportController : BaseController
    {
        private readonly IReportService _reportService;
        private readonly ICosoService _cosoService;

        public ReportController(IReportService reportService, ApplicationUserManager userManager, ApplicationSignInManager signInManager, IMapper mapper, ICosoService cosoService) : base(userManager, mapper, signInManager)
        {
            _reportService = reportService;
            _cosoService = cosoService;
        }

        [Route("api/report/ExportPDF/")]
        [HttpGet]
        public HttpResponseMessage ExportPDF()
        {
            var root = HostingEnvironment.MapPath("~/bin/Report");
            var path = Path.Combine(root, "RP_NHAPXUAT_PHIEU.rpt");

            var paras = new Dictionary<string, object>() {
                { "@UID", 2},
                { "@LCT", "XBAN"},
                { "@pDS_MAKHO", ""},
                { "@pTu", new DateTime(2000,01, 01)},
                { "@pDEN", new DateTime(2020,12,01)},
                { "@pDS_MADT", ""},

            };

            var fileBytes = _reportService.ExportPDF(path, new Dictionary<string, object>(), paras);
            string fileName = $"{Path.GetFileNameWithoutExtension(path)}.pdf";
            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(fileBytes)
            };
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = fileName
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/pdf");
            response.Content.Headers.ContentLength = fileBytes.Length;
            response.StatusCode = HttpStatusCode.OK;

            return response;

        }



        // GET api/values/5
        [Route("api/report/exportexcel/")]
        [HttpPost]
        public HttpResponseMessage ExportExcel([FromBody]SearchModel model)
        {

            //var root = System.Web.Hosting.HostingEnvironment.MapPath("~/bin/Reports");
            //var path = "";
            //var tinhtrangCode = tinhtrangs.First().Code;

            //switch (tinhtrangCode)
            //{
            //    case "toaantuyenkhongphamtoi":
            //        path = Path.Combine(root, "toaantuyenkhongphamtoiReport.rdl");
            //        break;
            //    case "trahosodieutrabosungvoicacvuandovksndtoicaophancong":
            //        path = Path.Combine(root, "vksndtoicaophancongReport.rdl");
            //        break;
            //    case "trahosodieutrabosungphantheonhomtoi":
            //        path = Path.Combine(root, "phantheonhomtoiReport.rdl");
            //        break;
            //    case "trahosodieutrabosung":
            //        path = Path.Combine(root, "trahosodieutrabosungReport.rdl");
            //        break;
            //    default:
            //        path = Path.Combine(root, "Report.rdl");
            //        break;
            //}
            //var dataset = new Dictionary<string, object>
            //{
            //    { "vuan", datasReport },
            //    { "CoSo", cosos },
            //    { "TinhTrangVuAn", tinhtrangs },
            //    { "HienThi", hienThi.ToList() },
            //    { "Huyen",  new List<HuyenModel> { huyen } }
            //};
            //var today = DateTime.Now;
            //var paras = new Dictionary<string, string>() {
            //    { "getAll", IsTinh.ToString()},
            //    { "fromDate", model.FromDate.Value.ToString("yyyy/MMM/dd")},
            //    { "toDate", model.ToDate.Value.ToString("yyyy/MMM/dd")},
            //    { "tenHuyen", huyen.Ten.ToUpper()},
            //    { "ngayText", $"{huyen.TenNganGon}, ngày {today.Day} tháng {today.Month} năm {today.Year}"},
            //    { "title1", $"CÁC VỤ ÁN, BỊ CAN DO {cosos.First().Ten} {tinhtrangs.First().Ten} THÁNG {model.FromDate?.ToString("MM/yyyy")}".ToUpper()},
            //    { "title2", $"Thời gian từ {model.FromDate?.ToString("dd/MM/yyyy")} đến ngày {model.ToDate?.ToString("dd/MM/yyyy")}".ToUpper()}
            //};
            var fileBytes = new byte[100]; //_reportService.ExportExcel(path, dataset, paras);
            var fileName = "";//$@"BaoCao-${cosos.First().Ten}-${tinhtrangs.First().Ten}-${DateTime.Now.ToString("dd-MM-yyyyHHmmss")}.xls";

            var response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                //Create a file on the fly and get file data as a byte array and send back to client
                Content = new ByteArrayContent(fileBytes)//Use your byte array
            };
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment");
            response.Content.Headers.ContentDisposition.FileName = fileName;//your file Name- text.xls
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/ms-excel");
            //response.Content.Headers.ContentType  = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentLength = fileBytes.Length;
            response.StatusCode = HttpStatusCode.OK;

            return response;
        }

    }
}
