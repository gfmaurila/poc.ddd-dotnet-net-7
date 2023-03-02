using Auth.Domain.Entities.Users;
using Auth.Domain.Validators;
using Xunit;

namespace Auth.Tests.Projects.Auth.Domain;

public class UserRoleTest
{
    [Fact]
    public void UserRole_IsValide()
    {
        // Arrange
        var obj = new UserRole(1, 1, "teste discriminator");

        var validator = new UserRoleValidator();

        Assert.Equal("teste discriminator", obj.Discriminator);
        Assert.Equal("teste discriminator", obj.Discriminator);

        Assert.True(obj.Validate());

        Assert.NotNull(obj.Discriminator);

        Assert.NotEmpty(obj.Discriminator);
    }
}

