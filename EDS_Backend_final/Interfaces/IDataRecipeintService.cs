using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface IDataRecipientService
    {
        Task<DataRecipient> GetDataRecipientAsync(int id);
        Task<IEnumerable<DataRecipient>> GetAllDataRecipientsAsync();
        Task<DataRecipient> CreateDataRecipientAsync(DataRecipient dataRecipient);
        Task<DataRecipient> UpdateDataRecipientAsync(int id, DataRecipient dataRecipient);
        Task<bool> DeleteDataRecipientAsync(int id);
    }
}
