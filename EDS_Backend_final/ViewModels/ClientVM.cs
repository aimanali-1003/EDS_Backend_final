using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class ClientViewModel
    {

        [Required]
        [MaxLength(255)]
        public string ClientName { get; set; }

        public string ClientCode { get; set; }

        [Required]

        public int OrganizationID { get; set; }
    }
}
