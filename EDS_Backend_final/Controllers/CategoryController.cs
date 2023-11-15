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

    }

}
