using Domain.Enum;

namespace Shared.DTO.TutorRequest;

public class TutorRequestResponseDto
{
    public int Id { get; set; }
    public required string CustomerName { get; set; }
    public required string CategoryName { get; set; }
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required DateTime StartDateTime { get; set; }
    public required DateTime EndDateTime { get; set; }
    public required decimal MinBudget { get; set; }
    public required decimal MaxBudget { get; set; }
    public TutorStatus Status { get; set; }
}
