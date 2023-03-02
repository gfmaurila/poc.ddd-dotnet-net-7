using Auth.App.Response;
using Auth.Infrastruture.CrossCutting.Handle;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Auth.Infrastruture.CrossCutting.Controllers;

[ApiController]
public abstract class MainController : ControllerBase
{
    private readonly INotificationHandle _notification;

    protected int UserId { get; set; }
    protected bool IsCustomer { get; set; } // valida se é uma gerenciamento do projeto ou empresa contratante 
    protected bool IsCompany { get; set; } // valida se os dados são de um usuario ou da empresa
    protected bool MainCompany { get; set; } // Valida se a empresa é pricipal
    protected int ProductId { get; set; }
    protected int AccountId { get; set; }

    protected bool AuthenticatedUser { get; set; }

    protected MainController(INotificationHandle notification)
    {
        _notification = notification;
        UserId = 1;
        IsCustomer = true;
        ProductId = 1;
        AccountId = 1;
        AuthenticatedUser = true;
    }

    protected bool IsValid()
    {
        return !_notification.IsNotification();
    }

    protected IActionResult CustomResponse(string mensagem, object result = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        if (IsValid())
        {
            return Ok(new ResponseDefault
            {
                Message = mensagem,
                Success = true,
                Data = result
            });
        }

        var error = new
        {
            success = false,
            errors = _notification.GetNotification().Select(n => n.Message)
        };

        return statusCode switch
        {
            HttpStatusCode.Forbidden => Forbid(),
            HttpStatusCode.BadRequest => BadRequest(error),
            _ => BadRequest(error)
        };
    }

    protected IActionResult Auth(object result = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        if (IsValid())
        {
            if (result != null)
            {
                return Ok(new ResponseDefault
                {
                    Message = "Usuário autenticado com sucesso!",
                    Success = true,
                    Data = result
                });
            }
            else
            {
                return StatusCode(401, Responses.UnauthorizedErrorMessage());
            }
        }

        var error = new
        {
            success = false,
            errors = _notification.GetNotification().Select(n => n.Message)
        };

        return statusCode switch
        {
            HttpStatusCode.Forbidden => Forbid(),
            HttpStatusCode.BadRequest => BadRequest(error),
            _ => BadRequest(error)
        };
    }

    protected IActionResult CustomResponse(object result = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
    {
        if (IsValid())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }

        var error = new
        {
            success = false,
            errors = _notification.GetNotification().Select(n => n.Message)
        };

        return statusCode switch
        {
            HttpStatusCode.Forbidden => Forbid(),
            HttpStatusCode.BadRequest => BadRequest(error),
            _ => BadRequest(error)
        };
    }

    protected IActionResult CustomResponse(ModelStateDictionary modelState)
    {
        if (!modelState.IsValid) NotifyInvalidModelError(modelState);
        return CustomResponse();
    }

    protected void NotifyInvalidModelError(ModelStateDictionary modelState)
    {
        var erros = modelState.Values.SelectMany(e => e.Errors);
        foreach (var erro in erros)
        {
            var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
            NotifyError(errorMsg);
        }
    }

    protected void NotifyError(string message)
    {
        _notification.Handle(new Notification(message));
    }
}