using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
    internal class TutorRequestConfiguration : IEntityTypeConfiguration<TutorRequest>
    {
        public void Configure(EntityTypeBuilder<TutorRequest> builder)
        {
            builder.Property(p => p.MaxBudget).HasColumnType("decimal(18,2)");
            builder.Property(p => p.MinBudget).HasColumnType("decimal(18,2)");


            builder.HasOne(tr => tr.Customer)
                .WithMany() 
                .HasForeignKey(tr => tr.CustomerId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tr => tr.Category)
                .WithMany(c => c.TutorRequestList)
                .HasForeignKey(tr => tr.CategoryID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Property(tr => tr.Status)
                   .HasConversion<string>() 
                   .IsRequired();

            builder.HasOne(tr => tr.AcceptedProposal)
                   .WithOne(p=>p.TutorRequest)
                   .HasForeignKey<TutorRequest>(tr => tr.AcceptedProposalId)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(tr => tr.Session)
                   .WithOne(s => s.TutorRequest)
                   .HasForeignKey<TutorRequest>(tr => tr.SessionID)
                   .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(tr => tr.ProposalList)
                .WithOne(p => p.TutorRequestMany)
                .HasForeignKey(p => p.TutorRequestID)
                .OnDelete(DeleteBehavior.Restrict);


        }
    }
}
