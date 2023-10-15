using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using EDS_Backend_final.ViewModels;

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

    }
}
