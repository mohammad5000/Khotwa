using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public class CategoryBadRequestException : BadRequestException
{
    public CategoryBadRequestException(string message) : base(message)
    {
    }
}
