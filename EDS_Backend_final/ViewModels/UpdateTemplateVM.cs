using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.ViewModels
{
    public class UpdateTemplateVM
    {
        public string TemplateName { get; set; }

        // Navigation property for the associated Category
        public int CategoryID { get; set; }
        public bool Active { get; set; }
        public List<int> ColumnsId { get; set; }

    }
}