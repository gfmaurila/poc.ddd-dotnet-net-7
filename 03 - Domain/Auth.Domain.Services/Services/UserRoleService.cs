using Auth.App.Dto.UserRole;
using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Users;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Auth.Domain.Services.Services;

public class UserRoleService : BaseService, IUserRoleService
{
    private readonly IMapper _mapper;
    private readonly IUserRoleRepository _repo;
    private readonly ILogger<UserRoleService> _logger;

    public UserRoleService(INotificationHandle notification, IMapper mapper, IUserRoleRepository repo, ILogger<UserRoleService> logger) : base(notification)
    {
        _mapper = mapper;
        _repo = repo;
        _logger = logger;
    }

    #region Command
    public async Task<CreateUserRoleDto> Create(CreateUserRoleDto dto)
    {
        var role = _mapper.Map<UserRole>(dto);
        role.Validate();
        role.Status = true;
        var created = await _repo.Create(role);
        return _mapper.Map<CreateUserRoleDto>(created);
    }

    public async Task<bool> Remove(int id)
        => await _repo.Remove(id);

    public async Task<bool> RemoveAll(UserRoleDto dto)
    {
        var all = await _repo.GetById(dto.UserId);
        if (all != null)
        {
            foreach (var item in all)
            {
                await Remove(item);
            }
            return true;
        }
        return false;
    }

    #endregion Command

    #region Query
    public async Task<List<UserRoleDto>> Get(UserRoleDto dto)
        => _mapper.Map<List<UserRoleDto>>(await _repo.GetById(_mapper.Map<UserRole>(dto)));

    public async Task<List<string>> GetByIdJwt(int userId)
        => _mapper.Map<List<string>>(await _repo.GetByIdJwt(userId));
    #endregion Query
}
