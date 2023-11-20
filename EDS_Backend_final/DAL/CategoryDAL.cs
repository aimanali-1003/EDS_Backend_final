using EDS_Backend_final.DataContext;
using EDS_Backend_final.Exceptions;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class CategoryDAL
    {
        private readonly DBContext _dbContext;

        public CategoryDAL(DBContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public async Task<Category> GetCategoryAsync(int id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _dbContext.Categories.Where(c => !c.IsDeleted).ToListAsync();
        }  

    }
}
