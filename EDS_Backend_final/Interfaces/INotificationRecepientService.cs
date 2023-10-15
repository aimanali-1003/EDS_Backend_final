using EDS_Backend_final.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Interfaces
{
    public interface INotificationRecipientService
    {
        Task<NotificationRecipient> GetNotificationRecipientAsync(int id);
        Task<IEnumerable<NotificationRecipient>> GetAllNotificationRecipientsAsync();
        Task<NotificationRecipient> CreateNotificationRecipientAsync(NotificationRecipient recipient);
        Task<NotificationRecipient> UpdateNotificationRecipientAsync(int id, NotificationRecipient recipient);
        Task<bool> DeleteNotificationRecipientAsync(int id);
    }
}
