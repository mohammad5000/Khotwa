using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTO.Demo
{
    public class DemoDto
    {
        [Required]
        [MaxLength(128, ErrorMessage = "URL Limit Exceeded")]
        public required string VideoUrl { get; set; }
        [Required]
        public required int ProposalId { get; set; }
    }
}
