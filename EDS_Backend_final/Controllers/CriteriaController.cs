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
    [Route("api/criteria")]
    [ApiController]
    public class CriteriaController : ControllerBase
    {
        private readonly ICriteriaService _criteriaService;
        private readonly IMapper _mapper;

        public CriteriaController(ICriteriaService criteriaService, IMapper mapper)
        {
            _criteriaService = criteriaService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCriteria()
        {
            var criteria = await _criteriaService.GetAllCriteriaAsync();
            return Ok(criteria);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCriteria(int id)
        {
            var criteria = await _criteriaService.GetCriteriaAsync(id);
            if (criteria == null)
                return NotFound();

            return Ok(criteria);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCriteria([FromBody] Criteria criteria)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdCriteria = await _criteriaService.CreateCriteriaAsync(_mapper.Map<Criteria>(criteria));
            return CreatedAtAction(nameof(GetCriteria), new { id = createdCriteria.CriteriaID }, _mapper.Map<Criteria>(createdCriteria));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCriteria(int id, [FromBody] Criteria criteriaVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var criteria = _mapper.Map<Criteria>(criteriaVM);
            var updatedCriteria = await _criteriaService.UpdateCriteriaAsync(id, criteria);
            if (updatedCriteria == null)
            {
                return NotFound();
            }
            var updatedCriteriaVM = _mapper.Map<Criteria>(updatedCriteria);

            return Ok(updatedCriteriaVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCriteria(int id)
        {
            var result = await _criteriaService.DeleteCriteriaAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
