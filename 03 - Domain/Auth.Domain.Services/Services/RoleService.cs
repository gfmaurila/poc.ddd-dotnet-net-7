using Auth.App.Dto.Role;
using Auth.Domain.Contract.Repositorys;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Users;
using Auth.Infrastruture.CrossCutting.Exceptions;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Auth.Domain.Services.Services;

public class RoleService : BaseService, IRoleService
{
    private readonly IMapper _mapper;
    private readonly IRoleRepository _repo;
    private readonly ILogger<RoleService> _logger;

    public RoleService(INotificationHandle notification, IMapper mapper, IRoleRepository repo, ILogger<RoleService> logger) : base(notification)
    {
        _mapper = mapper;
        _repo = repo;
        _logger = logger;
    }

    #region Command
    public async Task<RolesDto> Create(RolesDto dto)
    {
        var role = _mapper.Map<Role>(dto);

        var exists = await _repo.GetByNameById(role);

        if (exists != null)
            throw new Exceptions($"Já existe registro cadastrado com o nome: {dto.Name} informado.");

        role.Validate();
        role.NormalizedName = role.Name.ToUpper();
        role.ConcurrencyStamp = Guid.NewGuid().ToString();

        var created = await _repo.Create(role);
        return _mapper.Map<RolesDto>(created);
    }

    public async Task<RolesDto> Update(RolesDto dto)
    {
        var exists = await _repo.Get(dto.Id);

        if (exists == null)
            throw new Exceptions($"Não existe nenhum registo com o id: {dto.Id} informado!");

        var role = _mapper.Map<Role>(dto);
        role.Validate();
        role.NormalizedName = role.Name.ToUpper();
        role.ConcurrencyStamp = Guid.NewGuid().ToString();

        var updated = await _repo.Update(role);
        return _mapper.Map<RolesDto>(updated);
    }

    public async Task<bool> Remove(int id) => await _repo.Remove(id);

    #endregion Command

    #region Query
    public async Task<RolesDto> Get(int id) => _mapper.Map<RolesDto>(await _repo.Get(id));

    public async Task<List<RolesDto>> Get() => _mapper.Map<List<RolesDto>>(await _repo.Get());

    #endregion Query
}
