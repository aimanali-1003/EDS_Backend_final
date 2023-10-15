using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class ClientViewModel
    {
        public int ClientID { get; set; }

        [Required]
        [MaxLength(255)]
        public string ClientName { get; set; }
    }
}
