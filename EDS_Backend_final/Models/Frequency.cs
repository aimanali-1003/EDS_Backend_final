using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Frequency : AuditableEntity
    {
        [Key]
        public int FrequencyID { get; set; }

        [Required]
        [MaxLength(255)]
        public string FrequencyType { get; set; }

        [DataType(DataType.Time)]
        public DateTime? Time { get; set; }

        [DataType(DataType.Date)]
        public DateTime? Date { get; set; }

        public ICollection<DayOfWeek>? DaysOfWeek { get; set; }

        public int DateOfMonth { get; set; }

        public List<Job> Jobs { get; set; }
    }

    public class DayOfWeek
    {
        public int DayOfWeekId { get; set; }
        public int DayValue { get; set; }
    }

}
