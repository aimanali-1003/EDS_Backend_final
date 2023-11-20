using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Category : AuditableEntity
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

        public List<Columns> Columns { get; set; }
        public List<Template>? Templates { get; set; }
    }

}
