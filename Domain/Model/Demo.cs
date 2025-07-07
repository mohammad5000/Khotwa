using Domain.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Model
{
    public class Demo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(128, ErrorMessage = "URL Limit Exceeded")]
        public required string VideoUrl { get; set; }
        [Required]
        public DemoStatus Status { get; set; } = DemoStatus.Hold;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public virtual Proposal? Proposal { get; set; }
        

    }
}
