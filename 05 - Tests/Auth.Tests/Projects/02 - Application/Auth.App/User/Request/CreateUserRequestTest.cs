using Auth.App.Request.User;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.User.Request;
public class CreateUserRequestTest
{
    [Fact]
    public void User_IsValid()
    {
        var obj = new CreateUserRequest("51985623314", "email@email.com", "gfmaurila", "@G18u185236", "@G18u185236", true);

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
