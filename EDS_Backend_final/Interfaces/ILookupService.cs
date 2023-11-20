using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface ILookupService
    {
        Task<Lookup> GetLookupItemAsync(int id);
        Task<IEnumerable<Lookup>> GetAllLookupItemsAsync();
        Task<Lookup> CreateLookupItemAsync(Lookup lookup);
        Task<Lookup> UpdateLookupItemAsync(int id, Lookup lookup);
        Task<bool> DeleteLookupItemAsync(int id);
    }
}
