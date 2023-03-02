namespace Auth.App.Dto.Menssage;
public class SendGridDto
{
    public string PlainTextContent { get; set; }
    public string Subject { get; set; }
    public string HtmlContent { get; set; }
    public string To { get; set; }
    public string Name { get; set; }
}