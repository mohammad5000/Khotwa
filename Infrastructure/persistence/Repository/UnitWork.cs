using Domain.Interface;
using Infrastructure.persistence.Data;

namespace Infrastructure.persistence.Repository;

public class UnitWork : IUnitWork
{
    private readonly DataContext _context;

    public UnitWork(DataContext context)
    {
        _context = context;
    }

    public Task<int> SaveAsync()
    {
        return _context.SaveChangesAsync();
    }
}
