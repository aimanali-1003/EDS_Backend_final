using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class CriteriaService : ICriteriaService
    {
        private readonly CriteriaDAL _criteriaDAL;

        public CriteriaService(CriteriaDAL criteriaDAL)
        {
            _criteriaDAL = criteriaDAL;
        }

        public async Task<Criteria> GetCriteriaAsync(int id)
        {
            return await _criteriaDAL.GetCriteriaAsync(id);
        }

        public async Task<IEnumerable<Criteria>> GetAllCriteriaAsync()
        {
            return await _criteriaDAL.GetAllCriteriaAsync();
        }

        public async Task<Criteria> CreateCriteriaAsync(Criteria criteria)
        {
            return await _criteriaDAL.CreateCriteriaAsync(criteria);
        }

        public async Task<Criteria> UpdateCriteriaAsync(int id, Criteria criteria)
        {
            return await _criteriaDAL.UpdateCriteriaAsync(id, criteria);
        }

        public async Task<bool> DeleteCriteriaAsync(int id)
        {
            return await _criteriaDAL.DeleteCriteriaAsync(id);
        }
    }
}
