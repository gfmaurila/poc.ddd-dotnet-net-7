namespace Auth.Infrastruture.CrossCutting.Domain.Model;

public class Error
{
    public Error(string description, int code)
    {
        Description = description;
        Code = code;
    }

    public Error(string description)
    {
        Description = description;
    }

    public string Description { get; set; }
    public int Code { get; set; }
}
