using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Columns : AuditableEntity
    {
        [Key]
        public int ColumnsID{ get; set; }

        [Required]
        [MaxLength(255)]
        public string ColumnName { get; set; }

        [MaxLength(255)]
        public string ColumnCode { get; set; }

        public List<Category> Categories { get; set; }

        public List<TemplateColumns> TemplateColumns { get; set; }
    }
}
