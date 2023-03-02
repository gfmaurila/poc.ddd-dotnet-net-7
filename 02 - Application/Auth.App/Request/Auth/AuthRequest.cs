using Auth.App.Enums;
using System.ComponentModel.DataAnnotations;
namespace Auth.App.Request.Auth;

#region Reset Sennha
public class GenerateCodeResetRequest
{
    [Required(ErrorMessage = "O login não pode vazio.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O Type não pode vazio.")]
    public EGenerateCodeReset Type { get; set; }
}

public class RegisterNewPasswordRequest
{
    [StringLength(100, ErrorMessage = "O campo {0} precisa ter ao menos {2} caracteres", MinimumLength = 6)]
    public string NewPassword { get; set; }

    [StringLength(100, ErrorMessage = "O campo {0} precisa ter ao menos {2} caracteres", MinimumLength = 6)]
    [Compare("NewPassword", ErrorMessage = "As senhas não conferem.")]
    public string ConfirPassword { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string UserName { get; set; }
}

public class ValidateCodeResetRequest
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [StringLength(6, ErrorMessage = "O código precisa ter 6 dígitos.")]
    public string Code { get; set; }
}
#endregion

#region Login
public class LoginRequest
{
    [Required(ErrorMessage = "O login não pode vazio.")]
    public string Login { get; set; }

    [Required(ErrorMessage = "A senha não pode vazio.")]
    public string Password { get; set; }
}
#endregion

