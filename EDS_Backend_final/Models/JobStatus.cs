using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Models
{
    public class JobStatus : AuditableEntity
    {
        [Key]
        public int JobStatusID { get; set; }

        public string JobStatusName{ get; set; }

        public int JobID { get; set; }  // Foreign key property
        public Job Job { get; set; }    // Navigation property

    }
}
