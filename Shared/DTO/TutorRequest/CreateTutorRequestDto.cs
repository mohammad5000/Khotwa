using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.TutorRequest;

public class CreateTutorRequestDto
{
    [Required(ErrorMessage = "Customer ID is required")]
    public string CustomerId { get; set; } = null!;
    [Required(ErrorMessage = "Category ID is required")]
    public required int CategoryId { get; set; }
    [Required]
    [MaxLength(50, ErrorMessage = "Title Should not be greater than 50 Characters"),
    MinLength(20, ErrorMessage = "Title Should not be less than 20 Characters")]
    public required string Title { get; set; }
    [Required]
    [MaxLength(150, ErrorMessage = "Title Should not be more between 150 Characters")]
    public required string Description { get; set; }
    [Required(ErrorMessage = "Start time is required")]
    public DateTime StartDateTime { get; set; } = DateTime.UtcNow;
    [Required(ErrorMessage = "End time is required")]
    public DateTime EndDateTime { get; set; }
    [Required(ErrorMessage = "Minimum budget is required")]
    public decimal MinBudget { get; set; } = 5.00m;
    [Required(ErrorMessage = "Maximum budget is required")]
    public decimal MaxBudget { get; set; }
}
