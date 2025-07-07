using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Infrastructure.Configuration
{
    public class ProposalAvailableDateConfiguration : IEntityTypeConfiguration<ProposalAvailableDate>
    {
        public void Configure(EntityTypeBuilder<ProposalAvailableDate> builder) 
        {
            builder.HasKey(p => new { p.ProposalId, p.AvailableDateTime });

          
                builder.HasOne(p => p.Proposal)
                .WithMany(p => p.ListOfAvaliableDateTime)
                .HasForeignKey(p => p.ProposalId);
        }
    }
}
