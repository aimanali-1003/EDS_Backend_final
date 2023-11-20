using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class ColumnViewModel
    {
        [Key]
        public int ColumnsID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ColumnName { get; set; }

        [MaxLength(255)]
        public string ColumnCode { get; set; }

    }
}
