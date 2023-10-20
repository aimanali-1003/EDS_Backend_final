using EDS_Backend_final.Models;
using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class JobViewModel
    {
        [Key]
        public int JobID { get; set; }

        public string JobType { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        //navigation property
        public int FileFormatID { get; set; }

        //navigation property
        public int? OrgsOrganizationID { get; set; }
        public int TemplateID { get; set; }

        public bool? Active { get; set; }
    }
}
