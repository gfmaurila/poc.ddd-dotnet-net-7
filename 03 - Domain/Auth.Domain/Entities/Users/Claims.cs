namespace Auth.Domain.Entities.Users;

public class Claims : BaseEntity
{
    public int RoleId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}