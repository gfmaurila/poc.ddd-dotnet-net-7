using Auth.App.Dto.Identity;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.Role.Request;

public class CreateRoleRequestTest
{
    [Fact]
    public void Role_IsValid()
    {
        // Arrange
        var request = new CreateRolesRequest(
            name: "Teste Nome");

        Assert.Equal("Teste Nome", request.Name);

        Assert.NotNull(request.Name);

        Assert.NotEmpty(request.Name);
    }
}

