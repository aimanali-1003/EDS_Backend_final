using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IClientService
    {
        Task<Client> GetClientAsync(int id);
        Task<IEnumerable<Client>> GetAllClientsAsync();
        Task<Client> CreateClientAsync(Client client);
        Task<Client> UpdateClientAsync(int id, Client client);
        Task<bool> DeleteClientAsync(int id);

        Task<Org> GetOrgByIdAsync(int organizationId);

        Task<List<OrgVM>> GetOrganizationsForClientAsync(int clientId);
        //Task<bool> CheckIfClientExistsInJobTableAsync(int id);
    }
}
