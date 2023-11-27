using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Org : AuditableEntity
    {
        [Key]
        public int OrganizationID { get; set; }

        [Required]
        public string OrganizationCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string ParentOrganizationCode { get; set; }

        public string ParentOrganizationLevel { get; set; }

        public string OrganizationLevel { get; set; }

        public List<Client> Clients { get; set; }

        public List<OrgLevel> Levels { get; set; }

        public string PathToParents { get; set; }
    }
}