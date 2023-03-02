using Auth.Infrastruture.CrossCutting.Handle;
using FluentValidation.Results;

namespace Auth.Infrastruture.CrossCutting.Service;

public abstract class BaseService
{
    private readonly INotificationHandle _notification;
    protected BaseService(INotificationHandle notification)
    {
        _notification = notification;
    }

    protected void Notify(ValidationResult validationResult)
    {
        foreach (var error in validationResult.Errors)
        {
            Notify(error.ErrorMessage);
        }
    }

    protected void Notify(string message)
    {
        _notification.Handle(new Notification(message));
    }
}

