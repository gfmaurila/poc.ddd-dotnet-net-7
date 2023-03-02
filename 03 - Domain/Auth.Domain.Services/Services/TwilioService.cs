using Auth.App.Dto.Menssage;
using Auth.Domain.Contract.Repositorys.Mock;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Mock;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

using Twilio;
using Twilio.Rest.Api.V2010.Account;

namespace Auth.Domain.Services.Services;

public class TwilioService : BaseService, ITwilioService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;

    private readonly ISendManssageMockRepository _repo;

    public TwilioService(IConfiguration configuration,
                         INotificationHandle notification,
                         IMapper mapper,
                         ILogger<AuthService> logger,
                         ISendManssageMockRepository repo) : base(notification)
    {
        _configuration = configuration;
        _logger = logger;
        _mapper = mapper;
        _repo = repo;
    }

    public async Task TwilioSendMock(TwilioDto dto)
    {
        var mapper = _mapper.Map<SendManssageMock>(dto);
        mapper.Status = true;
        mapper.Modified = DateTime.Now;
        await _repo.AddAsync(mapper);
    }

    public async Task<string> TwilioSend(TwilioDto dto)
    {
        TwilioClient.Init(_configuration["Twilio:AccountSid"], _configuration["Twilio:AuthToken"]);

        var message = MessageResource.Create(
            body: dto.Body,
            from: new Twilio.Types.PhoneNumber(_configuration["Twilio:From"]),
            to: new Twilio.Types.PhoneNumber(dto.To)
        );

        return message.Sid;
    }
}
