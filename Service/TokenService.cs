using Domain.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Service.Abstraction;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Service;

public class TokenService : ITokenService
{
    private readonly IConfiguration config;
    private readonly UserManager<ApplicationUser> userManager;

    public TokenService(IConfiguration _config, UserManager<ApplicationUser> _userManager)
    {
        config = _config;
        userManager = _userManager;
    }
    public async Task<string> CreateToken(ApplicationUser user)
    {
        var tokenKey = config["TokenKey"] ?? throw new Exception("TokenKey not found in configuration.");

        if (tokenKey.Length < 64) throw new Exception("TokenKey must be at least 64 characters long.");

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenKey));

        var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

        var claims = new List<Claim>
        {
            new(ClaimTypes.NameIdentifier, user.Id),
            new(ClaimTypes.Name, user.FirstName+" "+user.LastName)

        };
        var roles = await userManager.GetRolesAsync(user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = credentials
        };

        var tokenHandler = new JwtSecurityTokenHandler();

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return tokenHandler.WriteToken(token);
    }
}
