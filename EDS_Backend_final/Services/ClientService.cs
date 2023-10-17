using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class ClientService : IClientService
    {
        private readonly ClientDAL _clientDAL;

        public ClientService(ClientDAL clientDAL)
        {
            _clientDAL = clientDAL;
        }

        public async Task<Client> GetClientAsync(int id)
        {
            return await _clientDAL.GetClientAsync(id);
        }

        public async Task<IEnumerable<Client>> GetAllClientsAsync()
        {
            return await _clientDAL.GetAllClientsAsync();
        }

        public async Task<Client> CreateClientAsync(Client client)
        {
            return await _clientDAL.CreateClientAsync(client);
        }

        public async Task<Client> UpdateClientAsync(int id, Client client)
        {
            return await _clientDAL.UpdateClientAsync(id, client);
        }

        public async Task<bool> DeleteClientAsync(int id)
        {
            return await _clientDAL.DeleteClientAsync(id);
        }

        public async Task<Org> GetOrgByIdAsync(int organizationId)
        {
            return await _clientDAL.GetOrgByIdAsync(organizationId);
        }

        public async Task<List<OrgVM>> GetOrganizationsForClientAsync(int clientId)
        {
            return await _clientDAL.GetOrganizationsForClientAsync(clientId);
        }
    }
}
