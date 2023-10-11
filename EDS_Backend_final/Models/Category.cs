using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Category : AuditableEntity
    {
        [Key]
        [Display(Name = "Category ID")]

        public int CategoryID { get; set; }

        [Required]
        [Display(Name = "Category Code")]
        public string CategoryCode { get; set; }

        [Required]
        [MaxLength(255)]
        [Display(Name = "Category Name")]
        public string CategoryName { get; set; }

        public List<Template>? Templates { get; set; }
    }

}
