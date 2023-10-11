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

        public TimeOnly? Time { get; set; }

        public DateOnly? Date { get; set; }

        public int[]? DaysOfWeek { get; set; }

        public int DateOfMonth { get; set; }

        public List<Job> Jobs { get; set; }
    }
}
