using Auth.App.Dto.User;

namespace Auth.Domain.Contract.Services;

public interface ITokenGeneratorService
{
    string GenerateToken(UserListDto user, List<string> roleList);
}
