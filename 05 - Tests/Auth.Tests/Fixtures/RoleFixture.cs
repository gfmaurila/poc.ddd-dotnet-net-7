using Auth.App.Dto.Identity;
using Auth.App.Dto.Role;
using Auth.Domain.Entities.Users;
using Auth.Domain.Model;
using Bogus.DataSets;

namespace Auth.Tests.Fixtures;
public class RoleFixture
{
    #region Valid
    public static Role CreateValid()
    {
        return new Role(name: "Teste", normalizedName: "Teste", concurrencyStamp: "Teste");
    }

    public static List<Role> CreateListValid(int limit = 5)
    {
        var list = new List<Role>();

        for (int i = 0; i < limit; i++)
            list.Add(CreateValid());
        return list;
    }

    public static PageModel CreateListSearchValid(int limit = 5)
    {
        var list = new List<Role>();

        for (int i = 0; i < limit; i++)
            list.Add(CreateValid());


        return new PageModel()
        {
            Results = list,
            Filter = new
            {
                Name = new Name().JobArea(),
            },
            PageNumber = 1,
            PageSize = 10,
            TotalCount = 1,
            TotalPages = 1
        };
    }

    public static RolesDto CreateValidDTO(bool newId = false)
    {
        return new RolesDto(name: new Name().JobTitle());
    }

    public static CreateRolesRequest CreateValidCreate()
    {
        return new CreateRolesRequest
        {
            Status = true,
            Name = new Name().JobTitle(),
        };
    }
    #endregion Valid

    #region Invalid
    public static RolesDto CreateInvalidDTO()
    {
        return new RolesDto
        {
            Name = new Name().JobTitle()
        };
    }

    public static CreateRolesRequest CreateInvalidCreateName()
    {
        return new CreateRolesRequest
        {
            Status = false,
            Name = ""
        };
    }
    #endregion Invalid
}
