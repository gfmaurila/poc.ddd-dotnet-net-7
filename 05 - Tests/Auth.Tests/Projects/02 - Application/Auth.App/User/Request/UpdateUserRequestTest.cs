using Auth.App.Request.User;
using Xunit;

namespace Auth.Tests.Projects._02___Application.Auth.App.User.Request;
public class UpdateUserRequestTest
{
    [Fact]
    public void User_IsValid()
    {
        var obj = new UpdateUserRequest(1, "51985624578", "email@email.com", true);
        Assert.NotNull(obj.PhoneNumber);
        Assert.NotEmpty(obj.PhoneNumber);

        Assert.NotNull(obj.Email);
        Assert.NotEmpty(obj.Email);

        Assert.True(obj.Status);
    }
}
