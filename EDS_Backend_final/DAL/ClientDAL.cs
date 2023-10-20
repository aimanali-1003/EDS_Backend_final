using EDS_Backend_final.DataContext;
using EDS_Backend_final.Exceptions;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class ClientDAL
    {
        private readonly DBContext _dbContext;

        public ClientDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Client> GetClientAsync(int id)
        {
            // Implement logic to retrieve a client by ID from your database
            return await _dbContext.Clients.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            // Implement logic to retrieve all clients from your database
            return await _dbContext.Clients.ToListAsync();
        }

        public async Task<Client> CreateClientAsync(Client client)
        {

            var isClientCodeUnique = await IsCategoryCodeUniqueAsync(client.ClientCode, 0);
            var isClientNameUnique = await IsCategoryNameUniqueAsync(client.ClientName, 0);

            if (!isClientCodeUnique || !isClientNameUnique)
            {
                // Category code or name is not unique, throw a custom exception
                throw new ValidationException("Client code or name is already exists");
            }

            if (!IsValidAlphanumeric(client.ClientCode) || !IsValidAlphanumeric(client.ClientName))
            {
                throw new ValidationException("Client code or name contains invalid characters");
            }


            client.CreatedAt = DateTime.Now;
            client.CreatedBy = "Zamaan";
            client.Active = true;

            // Implement logic to create a new client in your database
            _dbContext.Clients.Add(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(int id, Client client)
        {
            // Implement logic to update a client in your database
            var existingClient = await _dbContext.Clients.FindAsync(id);
            if (existingClient == null)
                return null; // Client not found

            if (existingClient == null)
            {
                // Category not found, throw a custom exception
                throw new ValidationException("Category not found");
            }

            if (!IsValidAlphanumeric(client.ClientCode) || !IsValidAlphanumeric(client.ClientName))
            {
                throw new ValidationException("Category code or name contains invalid characters");
            }

            if (client.ClientCode == existingClient.ClientCode && client.ClientName == existingClient.ClientName && client.Active == existingClient.Active)
            {
                throw new ValidationException("No changes were made");
            }

            // Update the properties of the existing client with the new data
            existingClient.ClientName = client.ClientName;
            existingClient.ClientCode = client.ClientCode;
            existingClient.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingClient.UpdatedBy = "Zamaan";
            existingClient.Active = client.Active;

            await _dbContext.SaveChangesAsync();
            return existingClient;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            var client = await _dbContext.Clients.FindAsync(id);
            if (client == null)
                return false;

            _dbContext.Clients.Remove(client);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Org> GetOrgByIdAsync(int organizationId)
        {
            try
            {
                var org = await _dbContext.Org.FindAsync(organizationId);
                return org;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or throw a custom exception)
                // You can also return null or a default value if organization not found
                throw;
            }
        }

        public async Task<List<OrgVM>> GetOrganizationsForClientAsync(int clientId)
        {
            try
            {
                var orgViewModels = await _dbContext.Clients
                    .Where(c => c.ClientID == clientId)
                    .Join(
                        _dbContext.Org,
                        client => client.Orgs.OrganizationID,
                        org => org.OrganizationID,
                        (client, org) => new OrgVM
                        {
                            OrganizationID = org.OrganizationID,
                            OrganizationCode = org.OrganizationCode,
                            OrganizationLevel = org.OrganizationLevel
                        }
                    )
                    .ToListAsync();

                return orgViewModels;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log or throw custom exceptions)
                throw;
            }
        }

        private async Task<bool> IsCategoryCodeUniqueAsync(string categoryCode, int categoryId)
        {
            return !await _dbContext.Categories.AnyAsync(c => c.CategoryCode == categoryCode && c.CategoryID != categoryId);
        }

        private async Task<bool> IsCategoryNameUniqueAsync(string categoryName, int categoryId)
        {
            return !await _dbContext.Categories.AnyAsync(c => c.CategoryName == categoryName && c.CategoryID != categoryId);
        }

        private bool IsValidAlphanumeric(string value)
        {
            var pattern = "^[a-zA-Z0-9 ]*$";
            return Regex.IsMatch(value, pattern);
        }
    }
}
