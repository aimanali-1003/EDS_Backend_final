using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/lookup")]
    [ApiController]
    public class LookupController : ControllerBase
    {
        private readonly ILookupService _lookupService;
        private readonly IMapper _mapper;

        public LookupController(ILookupService lookupService, IMapper mapper)
        {
            _lookupService = lookupService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetLookupItems()
        {
            var lookupItems = await _lookupService.GetAllLookupItemsAsync();
            return Ok(lookupItems);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetLookupItem(int id)
        {
            var lookupItem = await _lookupService.GetLookupItemAsync(id);
            if (lookupItem == null)
                return NotFound();

            return Ok(lookupItem);
        }

        [HttpPost]
        public async Task<IActionResult> CreateLookupItem([FromBody] Lookup lookupItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdLookupItem = await _lookupService.CreateLookupItemAsync(_mapper.Map<Lookup>(lookupItem));
            return CreatedAtAction(nameof(GetLookupItem), new { id = createdLookupItem.LookupID }, _mapper.Map<Lookup>(createdLookupItem));
        }

        // Add PUT and DELETE actions as needed.
    }
}
