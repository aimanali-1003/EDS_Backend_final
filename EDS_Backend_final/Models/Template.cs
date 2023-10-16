using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Template : AuditableEntity
    {
        [Key]
        public int TemplateID { get; set; }

        [Required]
        [MaxLength(255)]
        public string TemplateName { get ; set; }

        // Navigation property for the associated Category
        public Category Category { get; set; }

        public List<TemplateColumns>? TemplateColumns { get; set; }

        public List<Job>? Jobs { get; set; }
    }
}
