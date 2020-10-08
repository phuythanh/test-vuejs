using System;
using System.Collections.Generic;
using System.Text;

namespace bd.vienkiemsoat.web.Model.Models
{
    public class BaseModel
    {
        public Guid Id { get; set; }
        public string Ten { get; set; }
        public DateTime NgayTaoRecord { get; set; } = DateTime.Now;
        public Guid? UserId { get; set; }

    }

    public class BaseNgay
    {
        public double NgayConLai => (Date.GetValueOrDefault(DateTime.Now.Date).Date - DateTime.Now.Date).TotalDays;
        public DateTime? Date { get; set; }
    }
}
