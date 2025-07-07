using Domain.Interface;
using Domain.Model;
using Infrastructure.persistence.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.persistence.Repository;

public class TutorRequestRepository : ITutorRequestRepository
{
    private readonly DataContext _context;

    public TutorRequestRepository(DataContext context)
    {
        _context = context;
    }

    public void CreateTutorRequest(TutorRequest tutorRequest)
    {
        _context.TutorRequests.Add(tutorRequest);
    }

    public async Task<IEnumerable<TutorRequest>> GetAllTutorRequestsAsync()
    {
        return await _context.TutorRequests.Include(x => x.Category).Include(x => x.Customer).ToListAsync();
    }

    public async Task<TutorRequest?> GetTutorRequestByIdAsync(int id)
    {
        return await _context.TutorRequests.FindAsync(id);
    }
}
