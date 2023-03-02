using Auth.App.Dto.UserRole;
using Auth.App.Request.UserRole;
using Auth.Domain.Entities.Users;

namespace Auth.Tests.Fixtures;
public class UserRoleFixture
{
    #region Valid
    public static UserRole CreateValid()
    {
        return new UserRole(1, 1, "Teste");
    }

    public static List<UserRole> CreateListValid(int limit = 5)
    {
        var list = new List<UserRole>();

        for (int i = 0; i < limit; i++)
            list.Add(CreateValid());
        return list;
    }


    public static CreateUserRoleDto CreateValidDTO(bool newId = false)
    {
        return new CreateUserRoleDto(1, 1, "Teste");
    }

    public static CreateUserRoleRequest CreateValidCreate()
    {
        return new CreateUserRoleRequest
        {
            UserId = 1,
            RoleId = 1,
            Discriminator = "Teste"
        };
    }

    public static GetUserRoleRequest GetUserRoleValid()
    {
        return new GetUserRoleRequest
        {
            UserId = 1
        };
    }

    public static UserRoleDto GetUserRoleValidDto()
    {
        return new UserRoleDto
        {
            UserId = 1,
        };
    }

    public static UserRole GetUserRole()
    {
        return new UserRole
        {
            UserId = 1,
        };
    }
    #endregion Valid
}
