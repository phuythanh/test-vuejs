using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bd.vienkiemsoat.web.api.ViewModel
{
    public class SearchModel
    {
        public Guid CoSoId { get; set; }
        public Guid? TinhtrangId { get; set; }
        public Guid? HuyenId { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SearchText { get; set; }
        public string SearchKSV { get; set; }
    }

    public class SearchTinBaoModel
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string SearchText { get; set; }
        public string TinhTrang { get; set; }
        public string SearchKSV { get; set; }
        public Guid? HuyenId { get; set; }

    }
}
