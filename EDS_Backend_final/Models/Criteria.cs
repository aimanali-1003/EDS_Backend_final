using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Criteria : AuditableEntity
    {
        [Key]
        [Required]
        public int CriteriaID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }

        [MaxLength(255)]
        public string FilterColumnValue { get; set; }

        // Navigation property for the associated TemplateColumn
        public TemplateColumns TemplateColumn { get; set; }

        // Navigation property for the associated Lookup
        public Lookup? Lookup { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
