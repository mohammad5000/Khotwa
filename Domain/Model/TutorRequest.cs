using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Domain.Model
{
    public class TutorRequest
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public required string CustomerId { get; set; }

        [Required]
        public int CategoryID { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "Title Should not be greater than 50 Characters"),
        MinLength(20, ErrorMessage = "Title Should not be less between 20 Characters")]
        public required string Title { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Title Should not be more between 150 Characters")]
        public required string Description { get; set; }

        [Required]
        public required DateTime StartDateTime { get; set; } = DateTime.UtcNow;

        [Required]
        public required DateTime EndDateTime { get; set; }

        [Required]
        public decimal MinBudget { get; set; } = 5.00m;
        [Required]
        public decimal MaxBudget { get; set; }
        [Required]
        public TutorStatus Status { get; set; } = TutorStatus.OpenForApply;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;
        [ForeignKey("Proposal")]
        public int? AcceptedProposalId { get; set; }


        public int? SessionID { get; set; }


        public virtual Session? Session { get; set; }
        public virtual Proposal? AcceptedProposal { get; set; }
        public virtual ICollection<Proposal> ProposalList { get; set; } = new List<Proposal>();
        public virtual Category? Category { get; set; }
        public virtual ApplicationUser? Customer { get; set; }
    }
}

