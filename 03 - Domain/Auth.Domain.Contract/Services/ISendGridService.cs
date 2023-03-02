using Auth.App.Dto.Menssage;

namespace Auth.Domain.Contract.Services;
public interface ISendGridService
{
    Task SendGridSend(SendGridDto dto);
    Task SendGridMock(SendGridDto dto);
}
