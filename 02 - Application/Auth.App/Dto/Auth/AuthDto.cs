using Auth.App.Enums;

namespace Auth.App.Dto.Auth;

#region Login
public class LoginDto
{
    public string Login { get; set; }
    public string Password { get; set; }
}
#endregion

#region Token
public class TokenDto
{
    public string Token { get; set; }
    public DateTime TokenExpires { get; set; }
}
#endregion

#region Reset Sennha
public class GenerateCodeResetDto
{
    public string Login { get; set; }
    public EGenerateCodeReset Type { get; set; }
}

public class RegisterNewPasswordDto
{
    public string NewPassword { get; set; }
    public string ConfirPassword { get; set; }
    public string UserName { get; set; }
}

public class ValidateCodeResetDto
{
    public int UserId { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Code { get; set; }
}
#endregion