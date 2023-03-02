using Auth.App.Dto.User;
using Auth.Domain.Contract.Repositorys.View;
using Auth.Domain.Contract.Services.View;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Auth.Domain.Services.Services.View;

public class ViewUserService : BaseService, IViewUserService
{
    private readonly IMapper _mapper;
    private readonly IViewUserRepository _repo;
    private readonly ILogger<ViewUserService> _logger;

    public ViewUserService(INotificationHandle notification, IMapper mapper, IViewUserRepository repo, ILogger<ViewUserService> logger) : base(notification)
    {
        _mapper = mapper;
        _repo = repo;
        _logger = logger;
    }

    #region Query

    public async Task<List<ViewUserListDto>> Get()
         => _mapper.Map<List<ViewUserListDto>>(await _repo.Get());

    public async Task<ViewUserListDto> Get(int id)
         => _mapper.Map<ViewUserListDto>(await _repo.Get(id));

    public async Task<ViewUserListDto> GetByName(string name)
        => _mapper.Map<ViewUserListDto>(await _repo.GetByName(name));

    public async Task<List<ViewUserListDto>> SearchByName(string name)
        => _mapper.Map<List<ViewUserListDto>>(await _repo.SearchByName(name));

    #endregion Query
}
