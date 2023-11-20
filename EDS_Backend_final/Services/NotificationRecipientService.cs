using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class NotificationRecipientService : INotificationRecipientService
    {
        private readonly NotificationRecipientDAL _notificationRecipientDAL;

        public NotificationRecipientService(NotificationRecipientDAL notificationRecipientDAL)
        {
            _notificationRecipientDAL = notificationRecipientDAL;
        }

        public async Task<NotificationRecipient> GetNotificationRecipientAsync(int id)
        {
            return await _notificationRecipientDAL.GetNotificationRecipientAsync(id);
        }

        public async Task<IEnumerable<NotificationRecipient>> GetAllNotificationRecipientsAsync()
        {
            return await _notificationRecipientDAL.GetAllNotificationRecipientsAsync();
        }

        public async Task<NotificationRecipient> CreateNotificationRecipientAsync(NotificationRecipient recipient)
        {
            return await _notificationRecipientDAL.CreateNotificationRecipientAsync(recipient);
        }

        public async Task<NotificationRecipient> UpdateNotificationRecipientAsync(int id, NotificationRecipient recipient)
        {
            return await _notificationRecipientDAL.UpdateNotificationRecipientAsync(id, recipient);
        }

        public async Task<bool> DeleteNotificationRecipientAsync(int id)
        {
            return await _notificationRecipientDAL.DeleteNotificationRecipientAsync(id);
        }
    }
}
