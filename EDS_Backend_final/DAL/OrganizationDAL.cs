using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class OrganizationDAL
    {
        private readonly DBContext _dbContext;

        public OrganizationDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<Org> GetOrganizationAsync(int id)
        {
            // Implement logic to retrieve an organization by ID from your database
            return await _dbContext.Org.FindAsync(id);
        }

        public async Task<IEnumerable<Org>> GetAllOrganizationsAsync()
        {
            // Implement logic to retrieve all organizations from your database
            return await _dbContext.Org.ToListAsync();
        }

        public async Task<IEnumerable<Org>> SearchOrgs(string searchTerm)
        {
            var matchingOrgs = await _dbContext.Org
                .Where(org =>
                    org.OrganizationLevel.ToLower().Contains(searchTerm) ||
                    org.OrganizationCode.ToLower().Contains(searchTerm) ||
                    (org.ParentOrganizationCode != null && org.ParentOrganizationCode.ToLower().Contains(searchTerm))
                )
                .ToListAsync();

            foreach (var org in matchingOrgs)
            {
                org.PathToParents = GetPathToParents(org);
            }

            return matchingOrgs;
        }

        private string GetPathToParents(Org org)
        {
            var pathToParents = new List<string>();
            BuildPathToParent(org, pathToParents);
            return string.Join(" > ", pathToParents.AsEnumerable().Reverse());
        }

        private void BuildPathToParent(Org org, List<string> pathToParents)
        {
            pathToParents.Add(org.OrganizationCode);

            if (org.ParentOrganizationCode != null)
            {
                var parentOrg = _dbContext.Org.FirstOrDefault(o => o.OrganizationCode == org.ParentOrganizationCode);
                if (parentOrg != null)
                {
                    BuildPathToParent(parentOrg, pathToParents);
                }
            }
        }


        public async Task<List<ClientViewModel>> GetClientsForOrganizationAsync(int organizationId)
        {
            try
            {
                var clientViewModels = await _dbContext.Clients
                    .Where(c => c.OrgsOrganizationID == organizationId)
                    .Join(
                        _dbContext.Org,
                        client => client.Orgs.OrganizationID,
                        org => org.OrganizationID,
                        (client, org) => new ClientViewModel
                        {
                            ClientID = client.ClientID,
                            ClientName = client.ClientName,
                            ClientCode = client.ClientCode,

                        }
                    )
                    .ToListAsync();

                return clientViewModels;
            }
            catch (Exception ex)
            {
                // Handle exceptions appropriately (e.g., log or throw custom exceptions)
                throw;
            }

        }
    }
}