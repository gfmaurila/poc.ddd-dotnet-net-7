namespace Auth.App.Dto.UserRole;
public class CreateUserRoleDto
{
    public CreateUserRoleDto()
    {

    }
    public CreateUserRoleDto(int userId, int roleId, string discriminator)
    {
        UserId = userId;
        RoleId = roleId;
        Discriminator = discriminator;
    }

    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string Discriminator { get; set; }
}

public class UserRoleDto
{
    public UserRoleDto()
    {

    }
    public UserRoleDto(int id, int userId, int roleId, string discriminator)
    {
        Id = id;
        UserId = userId;
        RoleId = roleId;
        Discriminator = discriminator;
    }

    public int Id { get; set; }
    public int UserId { get; set; }
    public int RoleId { get; set; }
    public string Discriminator { get; set; }
}
