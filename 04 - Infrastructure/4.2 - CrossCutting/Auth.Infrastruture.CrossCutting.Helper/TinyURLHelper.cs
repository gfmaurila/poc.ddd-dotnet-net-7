using System.Net;

namespace Auth.Infrastruture.CrossCutting.Helper;

public static class TinyURLHelper
{
    public static string Urls(string longUrl)
    {
        string apiUrl = $"http://tinyurl.com/api-create.php?url={longUrl}";
        using (WebClient client = new WebClient())
        {
            string shortUrl = client.DownloadString(apiUrl);
            return shortUrl;
        }
    }
}
