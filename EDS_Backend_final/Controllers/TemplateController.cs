using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using EDS_Backend_final.DataAccess;
using EDS_Backend_final.DataContext;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace EDS_Backend_final.Controllers
{
    [Route("api/templates")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private readonly ITemplateService _templateService;
        private readonly IMapper _mapper;
        private readonly TemplateColDAL _templateColumnsDAL;
        private readonly DBContext _dbContext;

        public TemplateController(ITemplateService templateService, IMapper mapper, TemplateColDAL templateColumnsDAL, DBContext dbContext)
        {
            _templateService = templateService;
            _mapper = mapper;
            _templateColumnsDAL = templateColumnsDAL;
            _dbContext = dbContext;
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
        public async Task<IActionResult> CreateTemplate([FromBody] TemplateViewModel templateData)
        {
            
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var category = await _templateService.GetOrgByIdAsync(templateData.CategoryID);

            if (category == null)
            {
                return NotFound("Category not found");
            }

            var templateEntity = new Template
            {
                TemplateName = templateData.TemplateName,
                Category = category
            };

            var createdTemplate = await _templateService.CreateTemplateAsync(_mapper.Map<Template>(templateEntity));

            // Include the column names in the response
            var templateViewModel = _mapper.Map<TemplateViewModel>(createdTemplate);

            int templateId = templateViewModel.TemplateID;

            // Call the TemplateColDAL to create template columns
            var templateColumnsCreated = await _templateColumnsDAL.CreateTemplateColumnsAsync(templateId, templateData.ColumnsId.ToArray());

            if (!templateColumnsCreated)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Failed to create template columns");
            }

            return CreatedAtAction(nameof(GetTemplate), new { id = createdTemplate.TemplateID }, templateViewModel);
        }



        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTemplate(int id, [FromBody] UpdateTemplateVM templateVM)
        {
            if(!templateVM.Active)
            {
                if (_dbContext.Job.Any(j => j.TemplateID == id))
                {
                    throw new ValidationException("Template cannot be deactivated as it is present in the active job");
                }
            }
           
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(templateVM.ColumnsId!=null)
            {
                // Check if any data exists against the template ID
                var existingData = await _dbContext.TemplateColumns.AnyAsync(tc => tc.TemplateID == id);
                if (existingData)
                {
                    var templateColumns = _dbContext.TemplateColumns.Where(tc => tc.TemplateID == id);
                    _dbContext.TemplateColumns.RemoveRange(templateColumns);
                    await _dbContext.SaveChangesAsync(); // Save the changes to the database
                }

                var templateColumnsCreated = await _templateColumnsDAL.CreateTemplateColumnsAsync(id, templateVM.ColumnsId.ToArray());
            }
            

            var template = _mapper.Map<Template>(templateVM);
            var updatedTemplate = await _templateService.UpdateTemplateAsync(id, template);
            if (updatedTemplate == null)
            {
                return NotFound();
            }

            var updatedTemplateVM = _mapper.Map<Template>(templateVM);
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

        [HttpGet("lastCreatedId")]
        public async Task<IActionResult> GetLastCreatedTemplateId()
        {
            var lastTemplateId = await _templateService.GetLastCreatedTemplateIdAsync();
            return Ok(lastTemplateId);
        }

        //[HttpGet("getJob")]
        //public async Task<IActionResult> GetJobAssociatedWithTemplate(int templateId)
        //{
        //    var getJob = await _templateService.GetJob(templateId);
        //    return Ok(getJob);
        //}

        [HttpGet("GetColumnsOfTemplate")]
        public async Task<IActionResult> GetColumnsOfTemplate(int templateId)
        {
            try
            { 

                var TmplateColumn = await _dbContext.TemplateColumns
                .Include(tc => tc.Column)
                .Where(tc => tc.TemplateID == templateId)
                .OrderBy(tc => tc.TemplateColumnID)
                .ToListAsync();

                if (TmplateColumn == null || !TmplateColumn.Any())
                    return NotFound();
                

                var res = TmplateColumn.Select(tc => tc.Column.ColumnName).ToList();
                return Ok(res);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }



    }
}
