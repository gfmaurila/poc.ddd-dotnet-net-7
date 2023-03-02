using Auth.App.Request.User;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.User.Request;
public class UpdatePasswordUserRequestTest
{
    [Fact]
    public void User_IsValid()
    {
        var obj = new UpdatePasswordUserRequest(1, "@F18A03b1988", "@F18A03b1988", "email@email.com");


        Assert.NotNull(obj.UserName);
        Assert.NotEmpty(obj.UserName);

        Assert.NotNull(obj.NewPassword);
        Assert.NotEmpty(obj.NewPassword);

        Assert.NotNull(obj.ConfirmPassword);
        Assert.NotEmpty(obj.ConfirmPassword);
    }
}
