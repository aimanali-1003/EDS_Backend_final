using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class JobLog : AuditableEntity
    {
        [Key]
        public int JobLogID { get; set; }

        [Required]
        [DataType(DataType.DateTime)]
        public DateTime JobRunDateTime { get; set; }

        [Range(1, int.MaxValue)]
        public int JobRunDuration { get; set; }

        [Required]
        public bool ExtraxtSuccessFailure  { get; set; }

        [Required]
        public bool NotificationRecipientSuccessFailure { get; set; }

        [Range(0, int.MaxValue)]
        public int RecordCount { get; set; }
        public bool DataRecipientSuccessFailure { get; set; }

        // Navigation property for the associated Job
        public Job Job { get; set; }
    }
}
