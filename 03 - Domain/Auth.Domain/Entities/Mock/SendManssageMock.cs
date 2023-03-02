namespace Auth.Domain.Entities.Mock;
public class SendManssageMock : BaseEntity
{
    public SendManssageMock()
    {

    }
    public SendManssageMock(string? body, string? to, string? plainTextContent, string? subject, string? htmlContent, string? name)
    {
        Body = body;
        To = to;
        PlainTextContent = plainTextContent;
        Subject = subject;
        HtmlContent = htmlContent;
        Name = name;
    }

    public string? Body { get; set; }
    public string? To { get; set; }
    public string? PlainTextContent { get; set; }
    public string? Subject { get; set; }
    public string? HtmlContent { get; set; }
    public string? Name { get; set; }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}