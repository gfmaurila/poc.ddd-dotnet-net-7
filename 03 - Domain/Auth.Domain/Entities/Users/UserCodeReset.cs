namespace Auth.Domain.Entities.Users;

public class UserCodeReset : BaseEntity
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Code { get; set; }
    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}
