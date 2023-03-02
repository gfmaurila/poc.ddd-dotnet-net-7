using Auth.App.Dto.UserRole;
using Auth.App.Request.UserRole;
using Auth.Domain.Contract.Services;
using Auth.Infrastruture.CrossCutting.Controllers;
using Auth.Infrastruture.CrossCutting.Handle;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Config.Api.Controllers;

[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/v1/config/userrole")]
public class UserRoleController : MainController
{
    private readonly IMapper _mapper;
    private readonly IUserRoleService _service;
    private readonly ILogger<UserRoleController> _logger;

    public UserRoleController(INotificationHandle notification, IMapper mapper, IUserRoleService service, ILogger<UserRoleController> logger) : base(notification)
    {
        _mapper = mapper;
        _service = service;
        _logger = logger;
    }

    #region Cammand  
    [HttpPost("create")]
    public async Task<IActionResult> Create([FromBody] CreateUserRoleRequest request)
    {
        try
        {
            return CustomResponse("Registro salvo com sucesso!", await _service.Create(_mapper.Map<CreateUserRoleDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpDelete("remove/{id:int}")]
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

    [HttpDelete("removeall")]
    public async Task<IActionResult> Remove([FromBody] GetUserRoleRequest request)
    {
        try
        {
            return CustomResponse("Registro removido com sucesso!", await _service.RemoveAll(_mapper.Map<UserRoleDto>(request)));
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
    [HttpPost("getall")]
    public async Task<IActionResult> Get([FromBody] GetUserRoleRequest request)
    {
        try
        {
            return CustomResponse("Ok", await _service.Get(_mapper.Map<UserRoleDto>(request)));
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

