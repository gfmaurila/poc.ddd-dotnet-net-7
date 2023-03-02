namespace Auth.Domain.Entities.Users;

public class User : BaseEntity
{
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}
