﻿using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
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

        public async Task<List<ClientViewModel>> GetClientsForOrganizationAsync(int organizationId)
        {
            try
            {
                var clientViewModels = await _dbContext.Clients
                    .Where(c => c.OrgsOrganizationID == organizationId)
                    .Join(
                        _dbContext.Org,
                        client => client.Orgs.OrganizationID,
                        org => org.OrganizationID,
                        (client, org) => new ClientViewModel
                        {
                            ClientID = client.ClientID,
                            ClientName = client.ClientName,
                            ClientCode = client.ClientCode,
 
                        }
                    )
                    .ToListAsync();

                return clientViewModels;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log or throw custom exceptions)
                throw;
            }
        
        }
    }
}
