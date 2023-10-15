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
    [Route("api/templates")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        private readonly IMapper _mapper;

        public TemplateController(ITemplateService templateService, IMapper mapper)
        {
            _templateService = templateService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetTemplates()
        {
            var templates = await _templateService.GetAllTemplatesAsync();
            return Ok(templates);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTemplate(int id)
        {
            var template = await _templateService.GetTemplateAsync(id);
            if (template == null)
                return NotFound();

            return Ok(template);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTemplate([FromBody] Template template)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTemplate = await _templateService.CreateTemplateAsync(_mapper.Map<Template>(template));
            return CreatedAtAction(nameof(GetTemplate), new { id = createdTemplate.TemplateID }, _mapper.Map<Template>(createdTemplate));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTemplate(int id, [FromBody] Template templateVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var template = _mapper.Map<Template>(templateVM);
            var updatedTemplate = await _templateService.UpdateTemplateAsync(id, template);
            if (updatedTemplate == null)
            {
                return NotFound();
            }
            var updatedTemplateVM = _mapper.Map<Template>(updatedTemplate);

            return Ok(updatedTemplateVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTemplate(int id)
        {
            var result = await _templateService.DeleteTemplateAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }
}
