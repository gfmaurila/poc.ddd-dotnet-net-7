using Auth.App.Dto.User;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.User.Dto;
public class CreateUserDtoTest
{
    [Fact]
    public void User_IsValid()
    {
        var obj = new UserCreateDto("guilherme f maurila", "519856614", "gfmaurila@gmail.com", "gfmaurila", "@C18u03i1985", "@C18u03i1985", true);
        Assert.NotNull(obj.Name);
        Assert.NotEmpty(obj.Name);
        Assert.NotNull(obj.PhoneNumber);
        Assert.NotEmpty(obj.PhoneNumber);
        Assert.NotNull(obj.Email);
        Assert.NotEmpty(obj.Email);
        Assert.NotNull(obj.UserName);
        Assert.NotEmpty(obj.UserName);

        Assert.NotNull(obj.Password);
        Assert.NotEmpty(obj.Password);

        Assert.NotNull(obj.ConfirmPassword);
        Assert.NotEmpty(obj.ConfirmPassword);

        Assert.True(obj.Status);
    }
}
