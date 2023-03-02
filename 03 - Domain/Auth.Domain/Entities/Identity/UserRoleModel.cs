using Microsoft.AspNetCore.Identity;

namespace Auth.Domain.Entities.Identity;
public class UserRoleModel : IdentityUserRole<int>
{
    public bool Status { get; set; }
    public DateTime? Modified { get; set; }
}