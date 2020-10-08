using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace bd.vienkiemsoat.web.data.Entities
{
    public class CoSoEntity : BaseEntity
    {
        [MaxLength(500)]
        public string  Ten {get;set;}
        [MaxLength(500)]
        public string Code { get; set; }

        public int Index { get; set; }
    }
}
