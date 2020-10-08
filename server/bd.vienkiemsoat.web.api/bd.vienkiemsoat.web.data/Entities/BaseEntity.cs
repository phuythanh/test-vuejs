using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace bd.vienkiemsoat.web.data.Entities
{
    public class BaseEntity : IBaseEntity
    {
        [Key]
        public Guid Id { get; set; }

        [Column(TypeName = "datetime2")]
        public DateTime NgayTaoRecord { get; set; } = DateTime.Now;
        public Guid? UserId { get; set; }
    }

    public interface IBaseEntity
    {
        Guid Id { get; set; }
    }
}
