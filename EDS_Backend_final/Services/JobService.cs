using EDS_Backend_final.DataAccess;
using EDS_Backend_final.Interfaces;
using EDS_Backend_final.Models;
using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Net.Mime;
using System.Net;
using System.Threading.Tasks;

namespace EDS_Backend_final.Services
{
    public class JobService : IJobService
    {
        private readonly JobDAL _jobDAL;

        public JobService(JobDAL jobDAL)
        {
            _jobDAL = jobDAL;
        }

        public async Task<Job> GetJobAsync(int id)
        {
            return await _jobDAL.GetJobAsync(id);
        }

        public async Task<IEnumerable<Job>> GetAllJobsAsync()
        {
            return await _jobDAL.GetAllJobsAsync();
        }

        public async Task<Job> CreateJobAsync(Job job)
        {
            return await _jobDAL.CreateJobAsync(job);
        }

        public async Task<Job> UpdateJobAsync(int id, Job job)
        {
            return await _jobDAL.UpdateJobAsync(id, job);
        }

        public async Task<bool> DeleteJobAsync(int id)
        {
            return await _jobDAL.DeleteJobAsync(id);
        }

        public async Task<IEnumerable<FileFormat>> GetAllFileFormatsAsync()
        {
            return await _jobDAL.GetAllFileFormatsAsync();
        }

        public async Task<int?> GetFileFormatIdAsync(string type)
        {
            return await _jobDAL.GetFileFormatIdAsync(type);
        }

        public async Task<Job> GetJobWithRelatedEntitiesAsync(int jobId)
        {
            return await _jobDAL.GetJobWithRelatedEntitiesAsync(jobId);
        }


        public async Task SendEmailWithAttachment(string filePath, string recipientEmail)
        {

            var message = new MailMessage();
            message.From = new MailAddress("testingextractnoreply@gmail.com");
            message.To.Add(new MailAddress(recipientEmail));
            message.Subject = "Excel File Attachment";
            message.Body = "Please find the attached Excel file.";

            var attachment = new Attachment(filePath, MediaTypeNames.Application.Octet);
            message.Attachments.Add(attachment);

            using (var smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("testingextractnoreply@gmail.com", "ylnj lwgj botn wmog");
                smtp.EnableSsl = true;

                await smtp.SendMailAsync(message);
            }
        }

    }
}
