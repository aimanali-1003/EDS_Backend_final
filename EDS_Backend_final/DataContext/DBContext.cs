using EDS_Backend_final.Models;
using EDS_Backend_final.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace EDS_Backend_final.DataContext
{
    public class DBContext : DbContext 
    {
        public DBContext(DbContextOptions<DBContext> options) : base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryViewModel> CategoriesVM { get; set; }

        public DbSet<Org> Org { get; set; }

        public DbSet<OrgVM> OrgVM { get; set; }

        public DbSet<Client> Clients { get; set; }

        public DbSet<DataRecipientType> DataRecipientType { get; set; }

        public DbSet<Columns> Columns { get; set; }

        public DbSet<Criteria> Criteria { get; set; }
        public DbSet<DataRecipient> DataRecipient { get; set; }
        public DbSet<Frequency> Frequency { get; set; }
        public DbSet<Job> Job { get; set; }
        public DbSet<JobLog> JobLog { get; set; }
        public DbSet<JobStatus> JobStatus { get; set; }
        public DbSet<Lookup> Lookup { get; set; }
        public DbSet<NotificationRecipient> NotificationRecipient { get; set; }
        public DbSet<OrgLevel> OrgLevel { get; set; }
        public DbSet<TemplateColumns> TemplateColumns { get; set; }
        public DbSet<Template> Template { get; set; }

        public DbSet<FileFormat> FileFormat { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure the many-to-many relationship between Frequency and DayOfWeek
            modelBuilder.Entity<Frequency>()
                .HasMany(f => f.DaysOfWeek)
                .WithMany()
                .UsingEntity(junctionEntity =>
                {
                    junctionEntity.ToTable("FrequencyDayOfWeek"); // Name of the junction table
                });

        }


}
}
