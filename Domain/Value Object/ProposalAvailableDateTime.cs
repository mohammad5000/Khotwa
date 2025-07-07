using Domain.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class ProposalAvailableDate
{
    [Required]
    public DateTime AvailableDateTime { get; set; }

    [Required]
    [ForeignKey("Proposal")]
    public int ProposalId { get; set; }

    public Proposal? Proposal { get; set; }
}
