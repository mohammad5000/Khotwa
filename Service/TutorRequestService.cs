using Domain.Exceptions;
using Domain.Interface;
using Domain.Model;
using Service.Abstraction;
using Shared.DTO.TutorRequest;

namespace Service;

public class TutorRequestService : ITutorRequestService
{
    private readonly ITutorRequestRepository _tutorRequestRepository;
    private readonly ICategoryService _categoryService;
    private readonly IUnitWork _unitWork;

    public TutorRequestService(ITutorRequestRepository tutorRequestRepository, ICategoryService categoryService, IUnitWork unitWork)
    {
        _tutorRequestRepository = tutorRequestRepository;
        _categoryService = categoryService;
        _unitWork = unitWork;
    }

    public async Task CreateTutorRequestAsync(CreateTutorRequestDto createTutorRequestDto)
    {
        var Category = await _categoryService.GetCategoryByNameAsync(createTutorRequestDto.CategoryName);

        if (Category == null) throw new CategoryNotFoundException("Category not found.");

        var tutorRequest = new TutorRequest
        {
            Title = createTutorRequestDto.Title,
            Description = createTutorRequestDto.Description,
            StartDateTime = createTutorRequestDto.StartDateTime,
            EndDateTime = createTutorRequestDto.EndDateTime,
            MinBudget = createTutorRequestDto.MinBudget,
            MaxBudget = createTutorRequestDto.MaxBudget,
            CustomerId = createTutorRequestDto.CustomerId,
            CategoryID = Category.Id,
        };

        _tutorRequestRepository.CreateTutorRequest(tutorRequest);
        await _unitWork.SaveAsync();
    }

    public async Task<IEnumerable<TutorRequestResponseDto>> GetAllTutorRequestAsync()
    {
        var tutorRequests = await _tutorRequestRepository.GetAllTutorRequestsAsync();
        var tutorRequestDtos = new List<TutorRequestResponseDto>();

        foreach (var tutorRequest in tutorRequests)
        {
            tutorRequestDtos.Add(new TutorRequestResponseDto
            {
                Id = tutorRequest.Id,
                Title = tutorRequest.Title,
                Description = tutorRequest.Description,
                StartDateTime = tutorRequest.StartDateTime,
                EndDateTime = tutorRequest.EndDateTime,
                MinBudget = tutorRequest.MinBudget,
                MaxBudget = tutorRequest.MaxBudget,
                Status = tutorRequest.Status,
                CategoryName = tutorRequest.Category?.Name ?? "Unknown",
                CustomerName = tutorRequest.Customer?.FirstName + " " + tutorRequest.Customer?.LastName ?? "Unknown"
            });
        }

        if (tutorRequestDtos == null) throw new TutorRequestNotFoundException("Tutor requests not found.");

        return tutorRequestDtos;
    }

    public async Task<TutorRequestResponseDto?> GetTutorRequestByIdAsync(int id)
    {
        var tutorRequest = await _tutorRequestRepository.GetTutorRequestByIdAsync(id);

        if (tutorRequest == null) throw new TutorRequestNotFoundException("Tutor request not found.");

        return new TutorRequestResponseDto
        {
            Id = tutorRequest.Id,
            Title = tutorRequest.Title,
            Description = tutorRequest.Description,
            StartDateTime = tutorRequest.StartDateTime,
            EndDateTime = tutorRequest.EndDateTime,
            MinBudget = tutorRequest.MinBudget,
            MaxBudget = tutorRequest.MaxBudget,
            Status = tutorRequest.Status,
            CategoryName = tutorRequest.Category?.Name ?? "Unknown",
            CustomerName = tutorRequest.Customer?.FirstName + " " + tutorRequest.Customer?.LastName ?? "Unknown"
        };
    }
}