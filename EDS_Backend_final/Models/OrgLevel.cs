using System.ComponentModel.DataAnnotations;
using System.Reflection.Emit;

namespace EDS_Backend_final.Models
{
    public class OrgLevel : AuditableEntity
    {
        [Key]
        public int OrganizationLevelID { get; set; }

        public string SourceColumn { get; set; }

        public string OrganizationLevel { get; set; }

        public Org Org { get; set; }
    }
}
