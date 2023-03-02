using System.Text;

namespace Auth.Infrastruture.CrossCutting.Helper;

public static class EmailHelper
{
    public static string CreateEmailBody(string name, string link)
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine("<html>");
        sb.AppendLine("<body>");
        sb.AppendLine($"<h1>Olá, {name} segue link de validação onde você podera cadastrar uma nova senha </h1>");
        sb.AppendLine($"<div>Link de acesso, {link} </div>");
        sb.AppendLine("</body>");
        sb.AppendLine("</html>");
        return sb.ToString();
    }
}
