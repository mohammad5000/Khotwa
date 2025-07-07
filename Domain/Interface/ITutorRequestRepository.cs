using Domain.Model;

namespace Domain.Interface;

public interface ITutorRequestRepository
{
    Task<TutorRequest?> GetTutorRequestByIdAsync(int id);
    Task<IEnumerable<TutorRequest>> GetAllTutorRequestsAsync();
    void CreateTutorRequest(TutorRequest tutorRequest);
}
