using Auth.App.Dto.User;

namespace Auth.Domain.Contract.Services.View;
public interface IViewUserService
{
    Task<List<ViewUserListDto>> Get();
    Task<ViewUserListDto> Get(int id);
    Task<ViewUserListDto> GetByName(string name);
    Task<List<ViewUserListDto>> SearchByName(string name);
}
