using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
            return await _dbContext.Client.FindAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            // Implement logic to retrieve all clients from your database
            return await _dbContext.Client.ToListAsync();
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            client.CreatedAt = DateTime.Now;
            client.CreatedBy = "Zamaan";

            // Implement logic to create a new client in your database
            _dbContext.Client.Add(client);
            await _dbContext.SaveChangesAsync();
            return client;
        }

        public async Task<Client> UpdateClientAsync(int id, Client client)
        {
            // Implement logic to update a client in your database
            var existingClient = await _dbContext.Client.FindAsync(id);
            if (existingClient == null)
                return null; // Client not found

            // Update the properties of the existing client with the new data
            existingClient.ClientName = client.ClientName;
            existingClient.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingClient.UpdatedBy = "Zamaan";
            existingClient.Active = client.Active;

            await _dbContext.SaveChangesAsync();
            return existingClient;
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            // Implement logic to delete a client from your database
            var client = await _dbContext.Client.FindAsync(id);
            if (client == null)
                return false; // Client not found

            _dbContext.Client.Remove(client);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
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
    }
}
