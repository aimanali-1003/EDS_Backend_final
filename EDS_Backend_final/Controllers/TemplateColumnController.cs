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
    [Route("api/templatecolumns")]
    [ApiController]
    public class TemplateColumnController : ControllerBase
    {
        private readonly ITemplateColsService _templateColumnService;
        private readonly IMapper _mapper;

        public TemplateColumnController(ITemplateColsService templateColumnService, IMapper mapper)
        {
            _templateColumnService = templateColumnService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemplateColumns()
        {
            var templateColumns = await _templateColumnService.GetAllTemplateColsAsync();
            return Ok(templateColumns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplateColumn(int id)
        {
            var templateColumn = await _templateColumnService.GetTemplateColAsync(id);
            if (templateColumn == null)
                return NotFound();

            return Ok(templateColumn);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplateColumn([FromBody] TemplateColumns templateColumn)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTemplateColumn = await _templateColumnService.CreateTemplateColAsync(templateColumn);
            return CreatedAtAction(nameof(GetTemplateColumn), new { id = createdTemplateColumn.TemplateColumnID }, createdTemplateColumn);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTemplateColumn(int id, [FromBody] TemplateColumns templateColumnVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTemplateColumn = await _templateColumnService.UpdateTemplateColAsync(id, templateColumnVM);
            if (updatedTemplateColumn == null)
            {
                return NotFound();
            }

            return Ok(updatedTemplateColumn);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplateColumn(int id)
        {
            var result = await _templateColumnService.DeleteTemplateColAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
