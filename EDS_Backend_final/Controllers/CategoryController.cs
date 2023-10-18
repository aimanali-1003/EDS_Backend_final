using AutoMapper;
using EDS_Backend_final.Exceptions;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
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
        private readonly IColumnService _columnService;

        public CategoryController(ICategoryService categoryService, IMapper mapper, IColumnService columnService)
        {
            _categoryService = categoryService;
            _mapper = mapper;
            _columnService = columnService;
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

            var categoryViewModel = _mapper.Map<CategoryViewModel>(category);
            return Ok(categoryViewModel);
        }


        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CategoryViewModel category)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var createdCategory = await _categoryService.CreateCategoryAsync(_mapper.Map<Category>(category));
                return CreatedAtAction(nameof(GetCategory), new { id = createdCategory.CategoryID }, _mapper.Map<CategoryViewModel>(createdCategory));
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }


        }


        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCategory(int id, [FromBody] CategoryUpdateVM categoryVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var category = _mapper.Map<Category>(categoryVM);
                var updatedCategory = await _categoryService.UpdateCategoryAsync(id, category);
                if (updatedCategory == null)
                {
                    return NotFound();
                }
                var updatedCategoryVM = _mapper.Map<CategoryUpdateVM>(updatedCategory);

                return Ok(updatedCategoryVM);
            }
            catch (ValidationException ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await _categoryService.DeleteCategoryAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }

        [HttpGet("category-columns/{categoryId}")]
        public async Task<IActionResult> GetCategoryColumns(int categoryId)
        {
            var categoryColumns = await _columnService.GetColumnsByCategoryAsync(categoryId);

            if (categoryColumns == null || !categoryColumns.Any())
            {
                return NotFound();
            }

            return Ok(categoryColumns);
        }



    }

}
