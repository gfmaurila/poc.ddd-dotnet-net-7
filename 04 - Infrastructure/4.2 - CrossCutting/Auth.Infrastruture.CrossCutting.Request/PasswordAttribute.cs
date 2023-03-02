using System.ComponentModel.DataAnnotations;

namespace Auth.Infrastruture.CrossCutting.Request;
public class PasswordAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        string password = (string)value;
        if (string.IsNullOrWhiteSpace(password))
        {
            return new ValidationResult("Informe a senha");
        }
        if (password.Length < 8)
        {
            return new ValidationResult("A senha deve ter no mínimo 8 caracteres");
        }
        if (!password.Any(char.IsLower))
        {
            return new ValidationResult("A senha deve ter pelo menos 1 caracter minúsculo");
        }
        if (!password.Any(char.IsUpper))
        {
            return new ValidationResult("A senha deve ter pelo menos 1 caracter maiúsculo");
        }
        if (!password.Any(c => "@#_-!".IndexOf(c) != -1))
        {
            return new ValidationResult("A senha deve ter pelo menos 1 caracter especial (@,#,_,- e !)");
        }
        if (password.GroupBy(c => c).Any(g => g.Count() > 2))
        {
            return new ValidationResult("A senha não pode ter caracteres repetidos em sequência");
        }
        if (!password.Any(char.IsDigit))
        {
            return new ValidationResult("A senha deve ter pelo menos 1 número");
        }
        return ValidationResult.Success;
    }
}
