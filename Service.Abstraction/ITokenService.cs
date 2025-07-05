using Domain.Model;

namespace Service;

public interface ITokenService
{
    public string CreateToken(ApplicationUser user);
}
