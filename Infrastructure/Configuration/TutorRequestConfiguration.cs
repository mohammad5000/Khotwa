using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
    internal class TutorRequestConfiguration : IEntityTypeConfiguration<TutorRequest>
    {
        public void Configure(EntityTypeBuilder<TutorRequest> builder)
        {
            builder.Property(p => p.Budget).HasColumnType("decimal(18,2)");

            builder.HasOne(tr => tr.Customer)
                .WithMany() 
                .HasForeignKey(tr => tr.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tr => tr.Category)
                .WithMany()
                .HasForeignKey(tr => tr.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(tr => tr.Status)
                   .HasConversion<string>() 
                   .IsRequired();

            builder.HasOne(tr => tr.AcceptedProposal)
                   .WithMany()
                   .HasForeignKey(tr => tr.AcceptedProposalId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tr => tr.Session)
                   .WithMany()
                   .HasForeignKey(tr => tr.SessionId)
                   .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
