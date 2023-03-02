using Auth.App.Dto.User;
using Auth.App.Request.User;
using Auth.Domain.Contract.Services;
using Auth.Domain.Contract.Services.View;
using Auth.Infrastruture.CrossCutting.Controllers;
using Auth.Infrastruture.CrossCutting.Handle;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Config.Api.Controllers;


[Authorize(AuthenticationSchemes = "Bearer")]
[Route("api/v1/config/user")]
public class UserController : MainController
{
    private readonly IMapper _mapper;
    private readonly IUserManagerService _service;
    private readonly IViewUserService _viewUserservice;
    private readonly ILogger<UserController> _logger;

    public UserController(INotificationHandle notification, IMapper mapper, IUserManagerService service, IViewUserService viewUserservice, ILogger<UserController> logger) : base(notification)
    {
        _mapper = mapper;
        _service = service;
        _logger = logger;
        _viewUserservice = viewUserservice;
    }

    #region Cammand    
    [HttpPost("create")]
    [Authorize(Roles = "config-user-create")]
    public async Task<IActionResult> Create([FromBody] CreateUserRequest request)
    {
        try
        {
            return CustomResponse("Registro salvo com sucesso!", await _service.Create(_mapper.Map<UserCreateDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpPut("update")]
    [Authorize(Roles = "config-user-edit")]
    public async Task<IActionResult> Update([FromBody] UpdateUserRequest request)
    {
        try
        {
            return CustomResponse("Registro salvo com sucesso!", await _service.Update(_mapper.Map<UserUpdateDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpPut("updatepassword")]
    [Authorize(Roles = "config-user-edit-password")]
    public async Task<IActionResult> UpdatePassword([FromBody] UpdatePasswordUserRequest request)
    {
        try
        {
            return CustomResponse("Registro salvo com sucesso!", await _service.UpdatePassword(_mapper.Map<UserUpdatePasswordDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpDelete("remove/{id}")]
    [Authorize(Roles = "config-user-delete")]
    public async Task<IActionResult> Remove(string id)
    {
        try
        {
            await _service.Remove(id);
            return CustomResponse("Registro removido com sucesso!");
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
    [HttpGet("get/{id}")]
    [Authorize(Roles = "config-user-list")]
    public async Task<IActionResult> Get(string id)
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
    #endregion Query

    #region Query View

    [HttpGet("getall")]
    [Authorize(Roles = "config-user-list")]
    public async Task<IActionResult> Get()
    {
        try
        {
            return CustomResponse("Ok", await _viewUserservice.Get());
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpGet("getsearch/name/{name}")]
    [Authorize(Roles = "config-user-list")]
    public async Task<IActionResult> GetSearch([FromRoute] string name)
    {
        try
        {
            return CustomResponse("Ok", await _viewUserservice.SearchByName(name));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpGet("getbyname/name/{name}")]
    [Authorize(Roles = "config-user-list")]
    public async Task<IActionResult> GetByName([FromRoute] string name)
    {
        try
        {
            return CustomResponse("Ok", await _viewUserservice.GetByName(name));
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

