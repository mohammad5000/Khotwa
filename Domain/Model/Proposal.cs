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
        [ForeignKey("TutorRequest")]
        public int TutorRequestId { get; set; }

        [Required]
        [ForeignKey("Instructor")]
        public string InstructorId { get; set; }

        [Required]
        [MaxLength(150, ErrorMessage = "Title Should not be greater than 150 Characters")]
        public required string Message { get; set; }

        public ProposalStatus Status { get; set; } = ProposalStatus.Submited;

        public ApplicationUser Instructor { get; set; }
        public TutorRequest TutorRequest { get; set; }
    }
}
