using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Lookup : AuditableEntity
    {
        [Key]
        public int LookupID { get; set; }

        [Required]
        [MaxLength(255)]
        public string LookupType { get; set; }

        [MaxLength(255)]
        public string VisibleValue { get; set; }

        [MaxLength(255)]
        public string HiddenValue { get; set; }

        // Navigation property for one-to-many relationship with DataRecipient
        public List<DataRecipient> DataRecipients { get; set; }

        // Navigation property for one-to-many relationship with NotificationRecipient
        public List<NotificationRecipient> NotificationRecipients { get; set; }

        public List<Criteria> Criterias { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
