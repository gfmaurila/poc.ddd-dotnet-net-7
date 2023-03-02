using Auth.App.Dto.User;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.User.Dto;
public class UpdateUserDtoTest
{
    [Fact]
    public void User_IsValid()
    {
        var obj = new UserUpdateDto(1, "51985622214", "email@email.com", true);
        Assert.NotNull(obj.PhoneNumber);
        Assert.NotEmpty(obj.PhoneNumber);

        Assert.NotNull(obj.Email);
        Assert.NotEmpty(obj.Email);

        Assert.True(obj.Status);
    }
}
