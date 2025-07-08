using Domain.Exceptions.Base;

namespace Domain.Exceptions;

public class TutorRequestBadRequest : BadRequestException
{
    public TutorRequestBadRequest(string message) : base(message)
    {
    }
}
