using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Proposal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        
        public int TutorRequestID { get; set; }

        [Required]
        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }

        [ForeignKey("Demo")]
        public int DemoId { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Title Should not be greater than 150 Characters")]
        public required string Message { get; set; }

        [Required]
        public decimal PriceOffered { get; set; }

        public ICollection<ProposalAvailableDate> ListOfAvaliableDateTime { get; set; } = new List<ProposalAvailableDate>();
        public ProposalStatus Status { get; set; } = ProposalStatus.Submited;
        public virtual ApplicationUser? Instructor { get; set; }
        public virtual TutorRequest? TutorRequest { get; set; }
        public virtual TutorRequest? TutorRequestMany { get; set; }

        public virtual Demo? Demo { get; set; }
        
    }
}