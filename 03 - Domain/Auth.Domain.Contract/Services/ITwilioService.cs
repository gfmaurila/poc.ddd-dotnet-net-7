using Auth.App.Dto.Menssage;

namespace Auth.Domain.Contract.Services;
public interface ITwilioService
{
    Task<string> TwilioSend(TwilioDto dto);
    Task TwilioSendMock(TwilioDto dto);
}
