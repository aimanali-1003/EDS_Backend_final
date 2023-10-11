using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class DataRecipientType : AuditableEntity
    {
        [Key]
        public int RecipientTypeID { get; set; }

        [Required]
        public string RecipientType { get; set; }

        public DataRecipient DataRecipient { get; set; }
    }
}
