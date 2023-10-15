using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class OrganizationService : IOrganizationService
    {
        private readonly OrganizationDAL _organizationDAL;

        public OrganizationService(OrganizationDAL organizationDAL)
        {
            _organizationDAL = organizationDAL;
        }

        public async Task<Org> GetOrganizationAsync(int id)
        {
            return await _organizationDAL.GetOrganizationAsync(id);
        }

        public async Task<IEnumerable<Org>> GetAllOrganizationsAsync()
        {
            return await _organizationDAL.GetAllOrganizationsAsync();
        }

    }
}
