using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    internal class TutorRequestConfiguration : IEntityTypeConfiguration<TutorRequest>
    {
        public void Configure(EntityTypeBuilder<TutorRequest> builder)
        {
            
        
            builder.HasOne(tr => tr.Customer)
                .WithMany() 
                .HasForeignKey(tr => tr.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tr => tr.Category)
                .WithMany()
                .HasForeignKey(tr => tr.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
        


        builder.Property(p => p.Budget).HasColumnType("decimal(18,2)");
        }
    }
}
