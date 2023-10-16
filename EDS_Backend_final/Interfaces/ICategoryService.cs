using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryAsync(int id);
        Task<IEnumerable<Category>> GetAllCategoriesAsync();
        Task<Category> CreateCategoryAsync(Category category);
        Task<Category> UpdateCategoryAsync(int id, Category category);
        Task<bool> DeleteCategoryAsync(int id);

        //Task<IEnumerable<Columns>> GetCategoryColumnsAsync(int categoryId);
        //Task<IEnumerable<Category>> GetCategoriesWithColumnsAsync();
    }
}
