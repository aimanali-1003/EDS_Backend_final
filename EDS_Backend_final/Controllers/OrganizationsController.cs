using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EDS_Backend_final.ViewModels;
using EDS_Backend_final.DataAccess;

namespace EDS_Backend_final.Controllers
{
    [Route("api/organizations")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        private readonly IMapper _mapper;

        public OrganizationController(IOrganizationService organizationService, IMapper mapper)
        {
            _organizationService = organizationService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrganizations()
        {
            var organizations = await _organizationService.GetAllOrganizationsAsync();
            return Ok(organizations);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrganization(int id)
        {
            var organization = await _organizationService.GetOrganizationAsync(id);
            if (organization == null)
                return NotFound();

            return Ok(organization);
        }

        [HttpGet("{id}/clients")]
        public async Task<IActionResult> GetClientsForOrganization(int id)
        {
            try
            {
                var organization = await _organizationService.GetOrganizationAsync(id);
                if (organization == null)
                {
                    return NotFound();
                }

                var clients = await _organizationService.GetClientsForOrganizationAsync(id);
                return Ok(clients);
            }
            catch (Exception ex)
            {
                // Handle exceptions, log errors, etc.
                return StatusCode(500, ex.Message);
            }
        }

    }
}
