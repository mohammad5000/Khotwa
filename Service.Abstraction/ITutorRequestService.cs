using Domain.Model;
using Shared.DTO.TutorRequest;

namespace Service.Abstraction;

public interface ITutorRequestService
{
    Task<IEnumerable<TutorRequestResponseDto>> GetAllTutorRequestAsync();
    Task<TutorRequestResponseDto?> GetTutorRequestByIdAsync(int id);
    Task<TutorRequestResponseDto> CreateTutorRequestAsync(CreateTutorRequestDto createTutorRequestDto);
}
