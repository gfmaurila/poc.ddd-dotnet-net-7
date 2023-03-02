using Auth.Domain.Entities;

namespace Auth.Domain.View.User;
public class ViewUserList : BaseEntity
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }

    public override bool Validate()
    {
        throw new NotImplementedException();
    }
}
