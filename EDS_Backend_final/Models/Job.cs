using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Job : AuditableEntity
    {
        [Key]


                     
        public int JobID { get; set; }

        public string JobType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public bool? NotificationCheck { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinRecordCountAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxRecordCountAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MinRunDurationAlarm { get; set; }

        [Range(0, int.MaxValue)]
        public int? MaxRunDurationAlarm { get; set; }

        public int FileFormatID { get; set; }


        public int TemplateID { get; set; }

        public int FrequencyID { get; set; }

        public int DataRecipientID { get; set; }

        public int CriteriaID { get; set; }

        public int LookupID { get; set; }

        public int ClientID { get; set; }   

        public string? StartTime { get; set; }

        public Client? Client { get; set; }

        public Frequency? Frequency { get; set; }

        public Template? Template { get; set; }

        public FileFormat? FileFormat { get; set; }

        public DataRecipient? DataRecipient { get; set; }


    }
}
