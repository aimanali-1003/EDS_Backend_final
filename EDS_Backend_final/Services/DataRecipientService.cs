using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class DataRecipientService : IDataRecipientService
    {
        private readonly DataRecipientDAL _dataRecipientDAL;

        public DataRecipientService(DataRecipientDAL dataRecipientDAL)
        {
            _dataRecipientDAL = dataRecipientDAL;
        }

        public async Task<DataRecipient> GetDataRecipientAsync(int id)
        {
            return await _dataRecipientDAL.GetDataRecipientAsync(id);
        }

        public async Task<IEnumerable<DataRecipient>> GetAllDataRecipientsAsync()
        {
            return await _dataRecipientDAL.GetAllDataRecipientsAsync();
        }

        public async Task<DataRecipient> CreateDataRecipientAsync(DataRecipient dataRecipient)
        {
            return await _dataRecipientDAL.CreateDataRecipientAsync(dataRecipient);
        }

        public async Task<DataRecipient> UpdateDataRecipientAsync(int id, DataRecipient dataRecipient)
        {
            return await _dataRecipientDAL.UpdateDataRecipientAsync(id, dataRecipient);
        }

        public async Task<bool> DeleteDataRecipientAsync(int id)
        {
            return await _dataRecipientDAL.DeleteDataRecipientAsync(id);
        }

        public async Task<IEnumerable<DataRecipientType>> GetAllDataRecipientTypesAsync()
        {
            return await _dataRecipientDAL.GetAllDataRecipientTypesAsync();
        }
    }
}
