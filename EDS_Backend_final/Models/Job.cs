using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Job : AuditableEntity
    {
        [Key]
        public int JobID { get; set; }

        public bool? NotificationCheck { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinRecordRecordCountAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxRecordRecordCountAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinRunDurationAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxRunDurationAlarm { get; set; }

        public string JobType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string FileFormat { get; set; }

        public int DataRecipientFailAlarm  { get; set; }

        public int NotificationRecipientFailAlarm { get; set; }

        public Client Client { get; set; }

        public Criteria Criteria { get; set; }

        public Template Template { get; set; }

        public Frequency Frequency { get; set; }

        public Lookup? Lookup { get; set; }

        public List<JobLog> JobLogID { get; set; }

        public List<Job_Status> JobStatuses { get; set; }
    }
}
