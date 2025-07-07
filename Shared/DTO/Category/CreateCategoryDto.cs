using System.ComponentModel.DataAnnotations;

namespace Shared.DTO.Category;

public class CreateCategoryRequestDto
{
    [Required(ErrorMessage = "Category Name is Required")]
    public required string CategoryName { get; set; }
}
