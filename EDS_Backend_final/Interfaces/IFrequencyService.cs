using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IFrequencyService
    {
        Task<Frequency> GetFrequencyAsync(int id);
        Task<IEnumerable<Frequency>> GetAllFrequenciesAsync();
        Task<Frequency> CreateFrequencyAsync(Frequency frequency);
        Task<Frequency> UpdateFrequencyAsync(int id, Frequency frequency);
        Task<bool> DeleteFrequencyAsync(int id);

        Task<int?> GetFrequencyIdAsync(string frequencyType);
    }
}
