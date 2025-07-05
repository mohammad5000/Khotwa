
using Domain.Model;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Data
{
    public class DataContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }

        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) => 
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
    }
}
