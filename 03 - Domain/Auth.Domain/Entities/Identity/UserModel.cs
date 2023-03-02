using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Entities.Identity;
public class UserModel : IdentityUser<int>
{
    public bool Status { get; set; }
    public DateTime? Modified { get; set; }
}