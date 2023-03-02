using Auth.App.Dto.User;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.User.Dto;
public class UpdatePasswordUserDtoTest
{
    [Fact]
    public void User_IsValid()
    {
        var obj = new UserUpdatePasswordDto(1, "@G17l19a1986");

        Assert.Equal(1, obj.Id);

        Assert.NotNull(obj.NewPassword);
        Assert.NotEmpty(obj.NewPassword);

    }
}
