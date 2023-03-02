using Auth.App.Dto.Identity;
using Auth.App.Dto.Role;
using Auth.Domain.Contract.Services;
using Auth.Infrastruture.CrossCutting.Controllers;
using Auth.Infrastruture.CrossCutting.Handle;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Config.Api.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/v1/config/roles")]
public class RolesController : MainController
{
    private readonly IMapper _mapper;
    private readonly IRoleService _service;
    private readonly ILogger<RolesController> _logger;

    public RolesController(INotificationHandle notification, IMapper mapper, IRoleService service, ILogger<RolesController> logger) : base(notification)
    {
        _mapper = mapper;
        _service = service;
        _logger = logger;
    }

    #region Cammand  
    [HttpPost("create")]
    [Authorize(Roles = "config-user-create")]
    public async Task<IActionResult> Create([FromBody] CreateRolesRequest request)
    {
        try
        {
            return CustomResponse("Registro salvo com sucesso!", await _service.Create(_mapper.Map<RolesDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpPut("update")]
    [Authorize(Roles = "config-role-edit")]
    public async Task<IActionResult> Update([FromBody] UpdateRolesRequest request)
    {
        try
        {
            return CustomResponse("Registro salvo com sucesso!", await _service.Update(_mapper.Map<RolesDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpDelete("remove/{id:int}")]
    [Authorize(Roles = "config-role-delete")]
    public async Task<IActionResult> Remove([FromRoute] int id)
    {
        try
        {
            return CustomResponse("Registro removido com sucesso!", await _service.Remove(id));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }
    #endregion Cammand  

    #region Query
    [HttpGet("get/{id:int}")]
    [Authorize(Roles = "config-role-list")]
    public async Task<IActionResult> Get([FromRoute] int id)
    {
        try
        {
            return CustomResponse("Ok", await _service.Get(id));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpGet("getall")]
    [Authorize(Roles = "config-role-list")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return CustomResponse("Ok", await _service.Get());
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    #endregion Query
}

