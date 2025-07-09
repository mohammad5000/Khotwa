using AutoMapper;
using Domain.Enum;
using Domain.Model;
using Shared.DTO.Category;
using Shared.DTO.TutorRequest;

namespace Infrastructure.Helpers;

public class AutoMapperProfiles : Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<CreateCategoryRequestDto, Category>();
        CreateMap<Category, CategoryResponseDto>();

        CreateMap<TutorRequest, TutorRequestResponseDto>()
            .ForMember(d => d.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : "Unknown"))
            .ForMember(d => d.CustomerName, opt => opt.MapFrom(src => src.Customer != null
                ? $"{src.Customer.FirstName} {src.Customer.LastName}"
                : "Unknown")
        );
        CreateMap<CreateTutorRequestDto, TutorRequest>();
    }
}
