using Auth.App.Dto.Menssage;
using Auth.Domain.Contract.Repositorys.Mock;
using Auth.Domain.Contract.Services.Mock;
using Auth.Infrastruture.CrossCutting.Handle;
using Auth.Infrastruture.CrossCutting.Service;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Auth.Domain.Services.Services.Mock;

public class SendManssageMockService : BaseService, ISendManssageMockService
{
    private readonly IMapper _mapper;
    private readonly ISendManssageMockRepository _repo;
    private readonly ILogger<SendManssageMockService> _logger;

    public SendManssageMockService(INotificationHandle notification, IMapper mapper, ISendManssageMockRepository repo, ILogger<SendManssageMockService> logger) : base(notification)
    {
        _mapper = mapper;
        _repo = repo;
        _logger = logger;
    }

    #region Command
    public async Task<SendGridDto> CreateEmail(SendGridDto dto)
    {
        //var mapper = _mapper.Map<SendManssageMock>(dto);
        //mapper.Status = true;
        //var created = await _repo.Create(mapper);
        //return _mapper.Map<SendGridDto>(created);
        return null;
    }

    public async Task<TwilioDto> CreateWhatsApp(TwilioDto dto)
    {
        //var mapper = _mapper.Map<SendManssageMock>(dto);
        //mapper.Status = true;
        //var created = await _repo.Create(mapper);
        //return _mapper.Map<TwilioDto>(created);
        return null;
    }
    #endregion Command

}
