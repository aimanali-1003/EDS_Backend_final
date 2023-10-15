using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/org-levels")]
    [ApiController]
    public class OrgLevelController : ControllerBase
    {
        private readonly IOrgLevelService _orgLevelService;
        private readonly IMapper _mapper;

        public OrgLevelController(IOrgLevelService orgLevelService, IMapper mapper)
        {
            _orgLevelService = orgLevelService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrgLevels()
        {
            var orgLevels = await _orgLevelService.GetAllOrgLevelsAsync();
            return Ok(orgLevels);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrgLevel(int id)
        {
            var orgLevel = await _orgLevelService.GetOrgLevelAsync(id);
            if (orgLevel == null)
                return NotFound();

            return Ok(orgLevel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrgLevel([FromBody] OrgLevel orgLevel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdOrgLevel = await _orgLevelService.CreateOrgLevelAsync(_mapper.Map<OrgLevel>(orgLevel));
            return CreatedAtAction(nameof(GetOrgLevel), new { id = createdOrgLevel.OrganizationLevelID }, _mapper.Map<OrgLevel>(createdOrgLevel));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrgLevel(int id, [FromBody] OrgLevel orgLevelVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var orgLevel = _mapper.Map<OrgLevel>(orgLevelVM);
            var updatedOrgLevel = await _orgLevelService.UpdateOrgLevelAsync(id, orgLevel);
            if (updatedOrgLevel == null)
            {
                return NotFound();
            }
            var updatedOrgLevelVM = _mapper.Map<OrgLevel>(updatedOrgLevel);

            return Ok(updatedOrgLevelVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrgLevel(int id)
        {
            var result = await _orgLevelService.DeleteOrgLevelAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
