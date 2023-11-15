﻿using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class UpdateJobModel
    {
        [Key]
        public int JobID { get; set; }

        public string JobType { get; set; }

        public int? RecipientTypeID { get; set; }

        public DateTime? StartDate { get; set; }

        //navigation property
        public string FileFormatType { get; set; }

        public string? DayofWeek_Lkp { get; set; }

        //navigation property
        public int? OrgsOrganizationID { get; set; }
        public int TemplateID { get; set; }

        public int ClientID { get; set; }

        public bool? Active { get; set; }

        public string FrequencyType { get; set; }

        public string StartTime { get; set; }
        //public DateTime? EndTime { get; set; }

        public int? FrequencyID { get; set; }
    }
}
