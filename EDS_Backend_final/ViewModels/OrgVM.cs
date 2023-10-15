using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class OrgVM
    {
        [Key]
        public int OrganizationID { get; set; }

        [Required]
        public string OrganizationCode { get; set; }

        [Required]
        [MaxLength(255)]
        public string? ParentOrganizationCode { get; set; }

        public string? ParentOrganizationLevel { get; set; }

        public string OrganizationLevel { get; set; }
    }
}
