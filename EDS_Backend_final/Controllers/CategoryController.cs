using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EDS_Backend_final.Controllers
{
    [Route("api/categories")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetCategories()
        {
            var categories = await _categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategory(int id)
        {
            var category = await _categoryService.GetCategoryAsync(id);
            if (category == null)
                return NotFound();

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryViewModel category)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var categorys = _mapper.Map<Category>(category);
            var createdCategory = await _categoryService.CreateCategoryAsync(categorys);
            var createdCategoryViewModel = _mapper.Map<CategoryViewModel>(createdCategory);
            return CreatedAtAction(nameof(GetCategory), new { id = createdCategoryViewModel.CategoryID }, createdCategoryViewModel);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] Category category)
        {
            var updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);
            if (updatedCategory == null)
                return NotFound();

            return Ok(updatedCategory);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
    }

}
