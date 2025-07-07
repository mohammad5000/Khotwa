using Domain.Model;

namespace Service;

public interface ITokenService
{
    public Task<string> CreateToken(ApplicationUser user);
}
