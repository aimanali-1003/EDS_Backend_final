using EDS_Backend_final.Models;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EDS_Backend_final.ViewModels
{
    public class TemplateViewModel
    {
        [Key]
        public int TemplateID { get; set; }

        [Required]
        [MaxLength(255)]
        public string TemplateName { get; set; }

        // Navigation property for the associated Category
        public int CategoryID { get; set; }

        public List<int> ColumnsId { get; set; } 

    }
}
