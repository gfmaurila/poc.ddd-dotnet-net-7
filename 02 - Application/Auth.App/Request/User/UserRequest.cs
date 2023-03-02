using Auth.Infrastruture.CrossCutting.Request;
using System.ComponentModel.DataAnnotations;

namespace Auth.App.Request.User;


#region Create
public class CreateUserRequest
{
    public CreateUserRequest()
    {

    }
    public CreateUserRequest(string phoneNumber, string email, string userName, string password, string confirmPassword, bool status)
    {
        PhoneNumber = phoneNumber;
        Email = email;
        UserName = userName;
        Password = password;
        ConfirmPassword = confirmPassword;
        Status = status;
    }

    [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
    [Phone(ErrorMessage = "O campo {0} está em formato inválido")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string UserName { get; set; }

    /// <summary>
    /// Informe a senha
    /// A senha deve ter no mínimo 8 caracteres
    /// A senha deve ter pelo menos 1 caracter minúsculo
    /// A senha deve ter pelo menos 1 caracter maiúsculo
    /// A senha deve ter pelo menos 1 caracter especial (@,#,_,- e !
    /// A senha não pode ter caracteres repetidos em sequência
    /// A senha deve ter pelo menos 1 número
    /// </summary>
    [Password]
    public string Password { get; set; }

    [Compare("Password", ErrorMessage = "As senhas não conferem.")]
    public string ConfirmPassword { get; set; }

    public bool Status { get; set; }
}
#endregion

#region Update
public class UpdateUserRequest
{
    public UpdateUserRequest()
    {

    }

    public UpdateUserRequest(int id, string phoneNumber, string email, bool status)
    {
        Id = id;
        PhoneNumber = phoneNumber;
        Email = email;
        Status = status;
    }

    [Required(ErrorMessage = "O Id não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser menor que 1.")]
    public int Id { get; set; }

    [StringLength(11, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 8)]
    [Phone(ErrorMessage = "O campo {0} está em formato inválido")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} está em formato inválido")]
    public string Email { get; set; }

    public bool Status { get; set; }
}


public class UpdatePasswordUserRequest
{
    public UpdatePasswordUserRequest()
    {

    }
    public UpdatePasswordUserRequest(int id, string newPassword, string confirmPassword, string userName)
    {
        Id = id;
        NewPassword = newPassword;
        ConfirmPassword = confirmPassword;
        UserName = userName;
    }

    [Required(ErrorMessage = "O Id não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser menor que 1.")]
    public int Id { get; set; }

    /// <summary>
    /// Informe a senha
    /// A senha deve ter no mínimo 8 caracteres
    /// A senha deve ter pelo menos 1 caracter minúsculo
    /// A senha deve ter pelo menos 1 caracter maiúsculo
    /// A senha deve ter pelo menos 1 caracter especial (@,#,_,- e !
    /// A senha não pode ter caracteres repetidos em sequência
    /// A senha deve ter pelo menos 1 número
    /// </summary>
    [Password]
    public string NewPassword { get; set; }

    [Compare("NewPassword", ErrorMessage = "As senhas não conferem.")]
    public string ConfirmPassword { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    public string UserName { get; set; }

}

#endregion



