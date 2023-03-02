using Auth.App.Dto.Role;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.Role.Dto;

public class RoleDtoTest
{
    [Fact]
    public void Role_IsValide()
    {
        // Arrange
        var dto = new RolesDto(name: "Teste Nome");

        Assert.Equal("Teste Nome", dto.Name);

        Assert.NotNull(dto.Name);

        Assert.NotEmpty(dto.Name);
    }
}

