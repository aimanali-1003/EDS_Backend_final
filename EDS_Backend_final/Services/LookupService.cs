using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class LookupService : ILookupService
    {
        private readonly LookupDAL _lookupDAL;

        public LookupService(LookupDAL lookupDAL)
        {
            _lookupDAL = lookupDAL;
        }

        public async Task<Lookup> GetLookupItemAsync(int id)
        {
            return await _lookupDAL.GetLookupItemAsync(id);
        }

        public async Task<IEnumerable<Lookup>> GetAllLookupItemsAsync()
        {
            return await _lookupDAL.GetAllLookupItemsAsync();
        }

        public async Task<Lookup> CreateLookupItemAsync(Lookup item)
        {
            return await _lookupDAL.CreateLookupItemAsync(item);
        }

        public async Task<Lookup> UpdateLookupItemAsync(int id, Lookup item)
        {
            return await _lookupDAL.UpdateLookupItemAsync(id, item);
        }

        public async Task<bool> DeleteLookupItemAsync(int id)
        {
            return await _lookupDAL.DeleteLookupItemAsync(id);
        }
    }
}
