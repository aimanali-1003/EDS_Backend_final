using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class CategoryUpdateVM
    {
        [Key]
        public int CategoryID { get; set; }

        public string? CategoryCode { get; set; }

        public string? CategoryName { get; set; }

        public bool? Active { get; set; }
    }
}
