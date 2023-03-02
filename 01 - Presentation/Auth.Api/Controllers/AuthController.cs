using Auth.App.Dto.Auth;
using Auth.App.Dto.User;
using Auth.App.Request.Auth;
using Auth.App.Request.User;
using Auth.Domain.Contract.Services;
using Auth.Infrastruture.CrossCutting.Controllers;
using Auth.Infrastruture.CrossCutting.Handle;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.Controllers;

[ApiController]
[Route("api/v1/auth")]
public class AuthController : MainController
{
    private readonly IMapper _mapper;
    private readonly IAuthService _service;
    private readonly IUserService _serviceUser;
    private readonly IUserManagerService _serviceManager;
    private readonly ILogger<AuthController> _logger;

    public AuthController(INotificationHandle notification, IMapper mapper, IAuthService service, ILogger<AuthController> logger, IUserService serviceUser, IUserManagerService serviceManager) : base(notification)
    {
        _mapper = mapper;
        _service = service;
        _logger = logger;
        _serviceUser = serviceUser;
        _serviceManager = serviceManager;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Auth([FromBody] LoginRequest request)
    {
        try
        {
            return Auth(await _service.Auth(_mapper.Map<LoginDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpPost("generatecodereset")]
    public async Task<IActionResult> GenerateCodeReset([FromBody] GenerateCodeResetRequest request)
    {
        try
        {
            return CustomResponse(await _serviceUser.GenerateCodeReset(_mapper.Map<GenerateCodeResetDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpGet("validatecodereset/{code}")]
    public async Task<IActionResult> ValidateCodeReset(string code)
    {
        try
        {
            return CustomResponse(await _serviceUser.ValidateCodeReset(code));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }

    [HttpPost]
    [Route("registernewpassword")]
    public async Task<IActionResult> RegisterNewPassword([FromBody] UpdatePasswordUserRequest request)
    {
        try
        {
            return CustomResponse("Registro salvo com sucesso!", await _serviceManager.UpdatePassword(_mapper.Map<UserUpdatePasswordDto>(request)));
        }
        catch (Exception ex)
        {
            NotifyError(ex.InnerException?.Message ?? ex.Message);
            _logger.LogError(ex.InnerException?.Message ?? ex.Message, ex);
            return CustomResponse();
        }
    }
}

