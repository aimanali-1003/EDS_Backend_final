using EDS_Backend_final.DataContext;
using EDS_Backend_final.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EDS_Backend_final.DataAccess
{
    public class NotificationRecipientDAL
    {
        private readonly DBContext _dbContext;

        public NotificationRecipientDAL(DBContext dbContext) // Inject the DbContext through the constructor
        {
            _dbContext = dbContext;
        }

        public async Task<NotificationRecipient> GetNotificationRecipientAsync(int id)
        {
            // Implement logic to retrieve a notification recipient by ID from your database
            return await _dbContext.NotificationRecipient.FindAsync(id);
        }

        public async Task<IEnumerable<NotificationRecipient>> GetAllNotificationRecipientsAsync()
        {
            // Implement logic to retrieve all notification recipients from your database
            return await _dbContext.NotificationRecipient.ToListAsync();
        }

        public async Task<NotificationRecipient> CreateNotificationRecipientAsync(NotificationRecipient recipient)
        {
            recipient.CreatedAt = DateTime.Now;
            recipient.CreatedBy = "YourUsername"; // Set the creator's username
            // Implement logic to create a new notification recipient in your database
            _dbContext.NotificationRecipient.Add(recipient);
            await _dbContext.SaveChangesAsync();
            return recipient;
        }

        public async Task<NotificationRecipient> UpdateNotificationRecipientAsync(int id, NotificationRecipient recipient)
        {
            // Implement logic to update a notification recipient in your database
            var existingRecipient = await _dbContext.NotificationRecipient.FindAsync(id);
            if (existingRecipient == null)
                return null; // Recipient not found

            // Update the properties of the existing recipient with the new data
            existingRecipient.UpdatedAt = DateTime.Now; // Set the updated timestamp
            existingRecipient.UpdatedBy = recipient.UpdatedBy;

            await _dbContext.SaveChangesAsync();
            return existingRecipient;
        }

        public async Task<bool> DeleteNotificationRecipientAsync(int id)
        {
            // Implement logic to delete a notification recipient from your database
            var recipient = await _dbContext.NotificationRecipient.FindAsync(id);
            if (recipient == null)
                return false; // Recipient not found

            _dbContext.NotificationRecipient.Remove(recipient);
            await _dbContext.SaveChangesAsync();
            return true; // Deletion was successful
        }
    }
}
