using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class NotificationRecipient : AuditableEntity
    {
        [Key]
        public int NotificationRecipientID { get; set; }

        public string RecipientMethod { get; set; }

        public bool IsSubscribed { get; set; }

        public string? RecipientDetails { get; set; }

        // Navigation property for the associated Lookup
        public Lookup? Lookup { get; set; }

        // Navigation property for the associated client
        public Client Client { get; set; }
    }
}
