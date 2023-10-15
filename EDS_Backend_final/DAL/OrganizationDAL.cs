using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class OrganizationDAL
    {
        private readonly DBContext _dbContext;

        public OrganizationDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Org> GetOrganizationAsync(int id)
        {
            // Implement logic to retrieve an organization by ID from your database
            return await _dbContext.Org.FindAsync(id);
        }

        public async Task<IEnumerable<Org>> GetAllOrganizationsAsync()
        {
            // Implement logic to retrieve all organizations from your database
            return await _dbContext.Org.ToListAsync();
        }
    }
}
