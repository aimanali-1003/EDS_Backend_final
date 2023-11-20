using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EDS_Backend_final.ViewModels
{
    public class CategoryColumnViewModel
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Column> Columns { get; set; }
    }

}
