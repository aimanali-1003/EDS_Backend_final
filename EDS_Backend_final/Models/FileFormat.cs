using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class FileFormat
    {
        [Key]
        public int FileFormatID { get; set; }

        [Required]
        public string FileFormatName { get; set; }
    }
}
