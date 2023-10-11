using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class Job_Status : AuditableEntity
    {
        [Key]
        public int JobStatusID { get; set; }

        public string JobStatusName{ get; set; }

        public Job JobID { get; set; }
    }
}
