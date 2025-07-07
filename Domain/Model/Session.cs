using Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Model
{
    public class Session
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public required string MeetingUrl { get; set; }
        [Required]
        public DateTime ScheduleTime { get; set; }
        public string? RecordingUrl { get; set; }
        public SessionStatus Status { get; set; } = SessionStatus.Scheduled;
        
        public virtual TutorRequest? TutorRequest { get; set; }

    }
}
