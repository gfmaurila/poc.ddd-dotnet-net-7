namespace Auth.App;

public abstract class BaseEntityDto
{
    public int Id { get; set; }
    public DateTime? Modified { get; set; }
    public bool Status { get; set; }
}