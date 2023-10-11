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

            modelBuilder.Entity<Job>()
        .HasOne(j => j.Template)
        .WithMany(t => t.Jobs)
        .HasForeignKey(j => j.TemplateID)
        .OnDelete(DeleteBehavior.Restrict);





        }


}
}
