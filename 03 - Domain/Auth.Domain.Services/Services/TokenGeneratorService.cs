using Auth.App.Dto.User;
using Auth.Domain.Contract.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.Domain.Services.Services;

public class TokenGeneratorService : ITokenGeneratorService
{
    private readonly IConfiguration _configuration;
    private readonly ILogger<TokenGeneratorService> _logger;

    public TokenGeneratorService(IConfiguration configuration, ILogger<TokenGeneratorService> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    public string GenerateToken(UserListDto user, List<string> roleList)
    {
        var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(),
            Expires = DateTime.UtcNow.AddHours(int.Parse(_configuration["Jwt:HoursToExpire"])),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
            Issuer = _configuration["Jwt:Issuer"],
            Audience = _configuration["Jwt:Audience"]
        };

        tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Name, user.UserName));
        tokenDescriptor.Subject.AddClaim(new Claim("UserId", user.Id.ToString()));
        tokenDescriptor.Subject.AddClaim(new Claim("Email", user.Email.ToString()));
        tokenDescriptor.Subject.AddClaim(new Claim("UserName", user.UserName.ToString()));

        foreach (var role in roleList)
        {
            tokenDescriptor.Subject.AddClaim(new Claim(ClaimTypes.Role, role));
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}
