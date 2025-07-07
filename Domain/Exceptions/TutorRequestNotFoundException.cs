using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public class TutorRequestNotFoundException : NotFoundException
{
    public TutorRequestNotFoundException(string message) : base(message)
    {
    }
}
