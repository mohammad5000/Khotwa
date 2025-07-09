using AutoMapper;
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
    private readonly IMapper _mapper;
    private readonly IUnitWork _unitWork;

    public TutorRequestService(ITutorRequestRepository tutorRequestRepository, ICategoryService categoryService, IUnitWork unitWork, IMapper mapper)
    {
        _tutorRequestRepository = tutorRequestRepository;
        _categoryService = categoryService;
        _unitWork = unitWork;
        _mapper = mapper;
    }

    public async Task CreateTutorRequestAsync(CreateTutorRequestDto createTutorRequestDto)
    {
        if (createTutorRequestDto.MinBudget > createTutorRequestDto.MaxBudget)
            throw new TutorRequestBadRequest("Minimum budget cannot be greater than maximum budget.");

        if (createTutorRequestDto.StartDateTime >= createTutorRequestDto.EndDateTime)
            throw new TutorRequestBadRequest("End time must be after start time.");

        var result = await _categoryService.CheckCategoryExistsAsync(createTutorRequestDto.CategoryId)
            ? true : throw new CategoryNotFoundException("Category not found.");

        var tutorRequest = _mapper.Map<TutorRequest>(createTutorRequestDto);

        _tutorRequestRepository.CreateTutorRequest(tutorRequest);
        await _unitWork.SaveAsync();
    }

    public async Task<IEnumerable<TutorRequestResponseDto>> GetAllTutorRequestAsync()
    {
        var tutorRequests = await _tutorRequestRepository.GetAllTutorRequestsAsync();

        var tutorRequestDtos = _mapper.Map<IEnumerable<TutorRequestResponseDto>>(tutorRequests);

        if (tutorRequestDtos == null) throw new TutorRequestNotFoundException("Tutor requests not found.");

        return tutorRequestDtos;
    }

    public async Task<TutorRequestResponseDto?> GetTutorRequestByIdAsync(int id)
    {
        var tutorRequest = await _tutorRequestRepository.GetTutorRequestByIdAsync(id);

        if (tutorRequest == null) throw new TutorRequestNotFoundException("Tutor request not found.");

        return _mapper.Map<TutorRequestResponseDto>(tutorRequest);
    }
}