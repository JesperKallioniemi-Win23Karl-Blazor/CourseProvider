using CourseProvider.Infrastructure.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProvider.Infrastructure.Data.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {

        public DbSet<CourseEntity> Courses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies();
            }


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CourseEntity>().ToContainer("Courses");
            modelBuilder.Entity<CourseEntity>().HasPartitionKey(x => x.Id);
            modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Prices);
            modelBuilder.Entity<CourseEntity>().OwnsMany(x => x.Authors);
            modelBuilder.Entity<CourseEntity>().OwnsOne(x => x.Content);

            modelBuilder.Entity<CourseEntity>()
                .OwnsMany(x => x.ProgramDetails, pd =>
                {
                    pd.WithOwner().HasForeignKey("CourseEntityId");
                    pd.Property<int>("Id");
                    pd.HasKey("Id");
                });
        }
    }
}
