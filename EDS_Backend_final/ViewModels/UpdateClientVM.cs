using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class UpdateClientVM
    {
        public string? ClientName { get; set; }

        public string? ClientCode { get; set; }

        public bool Active { get; set; }

        public int OrganizationID { get; set; }
    }
}
