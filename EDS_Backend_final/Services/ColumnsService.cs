using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class ColumnsService : IColumnService
    {
        private readonly ColumnDAL _columnDAL;

        public ColumnsService(ColumnDAL columnDAL)
        {
            _columnDAL = columnDAL;
        }

        public async Task<Columns> GetColumnAsync(int id)
        {
            return await _columnDAL.GetColumnAsync(id);
        }

        public async Task<IEnumerable<Columns>> GetAllColumnsAsync()
        {
            return await _columnDAL.GetAllColumnsAsync();
        }

        public async Task<Columns> CreateColumnAsync(Columns column)
        {
            return await _columnDAL.CreateColumnAsync(column);
        }

        public async Task<Columns> UpdateColumnAsync(int id, Columns column)
        {
            return await _columnDAL.UpdateColumnAsync(id, column);
        }

        public async Task<bool> DeleteColumnAsync(int id)
        {
            return await _columnDAL.DeleteColumnAsync(id);
        }
    }
}
