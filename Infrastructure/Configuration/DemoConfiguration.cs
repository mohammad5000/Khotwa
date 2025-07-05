using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
    internal class DemoConfiguration : IEntityTypeConfiguration<Demo>
    {
        public void Configure(EntityTypeBuilder<Demo> builder)
        {

            builder.Property(d => d.Status)
                   .HasConversion<string>() 
                   .IsRequired();

           
        }
    }
}
