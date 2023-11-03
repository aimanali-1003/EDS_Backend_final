using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IOrganizationService
    {
        Task<Org> GetOrganizationAsync(int id);
        Task<IEnumerable<Org>> GetAllOrganizationsAsync();

        Task<List<ClientViewModel>> GetClientsForOrganizationAsync(int organizationId); 
    }
}
