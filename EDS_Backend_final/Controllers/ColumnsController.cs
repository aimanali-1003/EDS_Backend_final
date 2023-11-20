using AutoMapper;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using EDS_Backend_final.Services;
using EDS_Backend_final.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Controllers
{
    [Route("api/columns")]
    [ApiController]
    public class ColumnsController : ControllerBase
    {
        private readonly IColumnService _columnService;
        private readonly IMapper _mapper;

        public ColumnsController(IColumnService columnService, IMapper mapper)
        {
            _columnService = columnService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetColumns()
        {
            var columns = await _columnService.GetAllColumnsAsync();
            return Ok(columns);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetColumn(int id)
        {
            var column = await _columnService.GetColumnAsync(id);
            if (column == null)
                return NotFound();

            return Ok(column);
        }

        [HttpPost]
        public async Task<IActionResult> CreateColumn([FromBody] ColumnViewModel column)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdColumn = await _columnService.CreateColumnAsync(_mapper.Map<Columns>(column));
            return CreatedAtAction(nameof(GetColumn), new { id = createdColumn.ColumnsID }, _mapper.Map<ColumnViewModel>(createdColumn));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateColumn(int id, [FromBody] ColumnViewModel columnVM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var column = _mapper.Map<Columns>(columnVM);
            var updatedColumn = await _columnService.UpdateColumnAsync(id, column);
            if (updatedColumn == null)
            {
                return NotFound();
            }
            var updatedColumnVM = _mapper.Map<ColumnViewModel>(updatedColumn);

            return Ok(updatedColumnVM);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteColumn(int id)
        {
            var result = await _columnService.DeleteColumnAsync(id);
            if (!result)
                return NotFound();

            return NoContent();
        }
        [HttpGet("byCategory/{categoryId}")]
        public async Task<IActionResult> GetColumnsByCategory(int categoryId)
        {
            var columns = await _columnService.GetColumnsByCategoryAsync(categoryId);
            if (columns == null || columns.Count == 0)
                return NotFound();

            return Ok(columns);
        }
    }
}
