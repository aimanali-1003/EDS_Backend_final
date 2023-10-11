using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public abstract class AuditableEntity
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public bool Active { get; set; }
    }

}
