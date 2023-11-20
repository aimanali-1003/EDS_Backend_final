using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class FrequencyService : IFrequencyService
    {
        private readonly FrequencyDAL _frequencyDAL;

        public FrequencyService(FrequencyDAL frequencyDAL)
        {
            _frequencyDAL = frequencyDAL;
        }

        public async Task<Frequency> GetFrequencyAsync(int id)
        {
            return await _frequencyDAL.GetFrequencyAsync(id);
        }

        public async Task<IEnumerable<Frequency>> GetAllFrequenciesAsync()
        {
            return await _frequencyDAL.GetAllFrequenciesAsync();
        }

        public async Task<Frequency> CreateFrequencyAsync(Frequency frequency)
        {
            return await _frequencyDAL.CreateFrequencyAsync(frequency);
        }

        public async Task<Frequency> UpdateFrequencyAsync(int id, Frequency frequency)
        {
            return await _frequencyDAL.UpdateFrequencyAsync(id, frequency);
        }

        public async Task<bool> DeleteFrequencyAsync(int id)
        {
            return await _frequencyDAL.DeleteFrequencyAsync(id);
        }

        public async Task<int?> GetFrequencyIdAsync(string frequencyType)
        {
            return await _frequencyDAL.GetFrequencyIdAsync(frequencyType);
        }
    }
}
