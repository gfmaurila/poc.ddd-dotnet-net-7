namespace Auth.Domain.Model;

public class PageModel
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalCount { get; set; }
    public int TotalPages { get; set; }
    public object Filter { get; set; }
    public dynamic Results { get; set; }
}
