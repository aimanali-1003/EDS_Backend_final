using System.ComponentModel.DataAnnotations;
using System.Data.Common;

namespace EDS_Backend_final.Models
{
    public class TemplateColumns : AuditableEntity
    {
        [Key]
        public int TemplateColumnID { get; set; }

        public Template Template { get; set; }

        public Columns Column { get; set; }

        public List<Criteria> Criterias { get; set; }
    }
}
