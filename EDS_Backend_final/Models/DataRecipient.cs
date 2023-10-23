using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class DataRecipient : AuditableEntity
    {
        [Key]
        public int RecipientID { get; set; }

        // Navigation property for the associated Lookup
        public Lookup? Lookup { get; set; }

        // Navigation property for the associated client
        public int? ClientID { get; set; }
        public Client? Client { get; set; }

        public int? RecipientTypeID { get; set; }

        public DataRecipientType? DataRecipientType { get; set; }
    }
}
