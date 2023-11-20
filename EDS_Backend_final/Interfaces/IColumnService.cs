using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IColumnService
    {
        Task<Columns> GetColumnAsync(int id);
        Task<IEnumerable<Columns>> GetAllColumnsAsync();
        Task<Columns> CreateColumnAsync(Columns column);
        Task<Columns> UpdateColumnAsync(int id, Columns column);
        Task<bool> DeleteColumnAsync(int id);

        Task<List<CategoryColumnDTO>> GetColumnsByCategoryAsync(int categoryId);
    }
}
