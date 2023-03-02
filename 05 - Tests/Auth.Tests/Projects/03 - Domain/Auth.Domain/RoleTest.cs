using Auth.Domain.Entities.Users;
using Auth.Domain.Validators;
using Xunit;

namespace Auth.Tests.Projects.Auth.Domain;

public class RoleTest
{
    [Fact]
    public void Role_IsValide()
    {
        // Arrange
        var obj = new Role("Teste Name", "teste normalizedName", "teste concurrencyStamp");

        var validator = new RoleValidator();

        Assert.Equal("Teste Name", obj.Name);
        Assert.Equal("teste normalizedName", obj.NormalizedName);
        Assert.Equal("teste concurrencyStamp", obj.ConcurrencyStamp);

        Assert.True(obj.Validate());

        Assert.NotNull(obj.Name);

        Assert.NotEmpty(obj.Name);
    }
}

