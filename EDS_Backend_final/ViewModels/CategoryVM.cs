using System.ComponentModel.DataAnnotations;
using EDS_Backend_final.Models;

namespace EDS_Backend_final.ViewModels
{
    public class CategoryViewModel
    {
        [Key]
        public int CategoryID { get; set; }

        [Required]
        public string CategoryCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string CategoryName { get; set; }

    }
}
