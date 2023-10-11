using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Client : AuditableEntity
    {
        [Key]
        public int ClientID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ClientName { get; set; }

        [Required]
        public string ClientCode { get; set; }

        // Foreign Key
        // Navigation property
        public Org Orgs { get; set; }
    }
}
