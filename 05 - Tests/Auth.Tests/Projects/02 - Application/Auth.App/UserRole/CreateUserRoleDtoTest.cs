﻿using Auth.App.Dto.UserRole;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.UserRole;

public class CreateUserRoleDtoTest
{
    [Fact]
    public void UserRole_IsValid()
    {
        var obj = new CreateUserRoleDto(1, 1, "teste");

        Assert.Equal(1, obj.UserId);
        Assert.Equal(1, obj.RoleId);

        Assert.NotNull(obj.Discriminator);
        Assert.NotEmpty(obj.Discriminator);
    }
}
