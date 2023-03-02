using Auth.App.Dto.Menssage;
using Auth.Domain.Contract.Repositorys.Mock;
using Auth.Domain.Contract.Services;
using Auth.Domain.Entities.Mock;
using Auth.Infrastruture.CrossCutting.Handle;
using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Net;

namespace Auth.Domain.Services.Services;

public class SendGridService : ISendGridService
{
    private readonly IMapper _mapper;
    private readonly IConfiguration _configuration;
    private readonly ILogger<AuthService> _logger;

    private readonly ISendManssageMockRepository _repo;

    public SendGridService(IConfiguration configuration,
                           INotificationHandle notification,
                           ISendManssageMockRepository repo,
                           IMapper mapper,
                           ILogger<AuthService> logger)
    {
        _configuration = configuration;
        _logger = logger;
        _mapper = mapper;
        _repo = repo;
    }

    public async Task SendGridMock(SendGridDto dto)
    {
        var mapper = _mapper.Map<SendManssageMock>(dto);
        mapper.Status = true;
        mapper.Modified = DateTime.Now;
        await _repo.AddAsync(mapper);
    }

    public async Task SendGridSend(SendGridDto dto)
    {
        var client = new SendGridClient(_configuration["SendGrid:Key"]);

        var from = new EmailAddress(_configuration["SendGrid:From"], _configuration["SendGrid:User"]);

        var subject = dto.Subject;
        var to = new EmailAddress(dto.To, dto.Name);

        var plainTextContent = dto.PlainTextContent;
        var htmlContent = dto.HtmlContent;

        var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent, htmlContent);

        var response = await client.SendEmailAsync(msg)
                                   .ConfigureAwait(false);

        if (response.StatusCode != HttpStatusCode.OK && response.StatusCode != HttpStatusCode.Accepted)
        {
            var erro = await response.Body.ReadAsStringAsync();
            throw new Exception($"Falha ao enviar e-mail: {erro}");
        }
    }
}
