using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Service.Abstraction;
using Shared.DTO.TutorRequest;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TutorRequestController : ControllerBase
    {
        private readonly ITutorRequestService _tutorRequestService;

        public TutorRequestController(ITutorRequestService tutorRequestService)
        {
            _tutorRequestService = tutorRequestService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TutorRequestResponseDto>>> GetAllTutorRequestAsync()
        {
            var tutorRequests = await _tutorRequestService.GetAllTutorRequestAsync();
            return Ok(tutorRequests);
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<TutorRequestResponseDto?>> GetTutorRequestByIdAsync(int id)
        {
            var tutorRequest = await _tutorRequestService.GetTutorRequestByIdAsync(id);
            return Ok(tutorRequest);
        }

        [HttpPost]
        public async Task<ActionResult> CreateTutorRequestAsync(CreateTutorRequestDto createTutorRequestDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _tutorRequestService.CreateTutorRequestAsync(createTutorRequestDto);
            return Created();
        }
    }
}