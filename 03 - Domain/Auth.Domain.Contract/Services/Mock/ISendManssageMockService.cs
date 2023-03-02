using Auth.App.Dto.Menssage;

namespace Auth.Domain.Contract.Services.Mock;
public interface ISendManssageMockService
{
    Task<SendGridDto> CreateEmail(SendGridDto dto);
    Task<TwilioDto> CreateWhatsApp(TwilioDto dto);
}
