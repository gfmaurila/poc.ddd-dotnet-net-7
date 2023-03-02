using System.ComponentModel.DataAnnotations;

namespace Auth.App.Request.UserRole;

public class CreateUserRoleRequest
{
    public CreateUserRoleRequest()
    {

    }

    public CreateUserRoleRequest(int userId, int roleId, string discriminator)
    {
        UserId = userId;
        RoleId = roleId;
        Discriminator = discriminator;
    }

    [Required(ErrorMessage = "O UserId não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O UserId não pode ser menor que 1.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "O RoleId não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O UserId não pode ser menor que 1.")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "O Discriminator não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O Discriminator deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O Discriminator deve ter no máximo 80 caracteres.")]
    public string Discriminator { get; set; }

}

public class GetUserRoleRequest
{
    public int UserId { get; set; }

    public int RoleId { get; set; }
}

public class UserRoleRequest
{
    public int Id { get; set; }
    public int UserId { get; set; }

    public int RoleId { get; set; }
    public string Discriminator { get; set; }

}

public class UpdateUserRoleRequest
{
    [Required(ErrorMessage = "O Id não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser menor que 1.")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O UserId não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O UserId não pode ser menor que 1.")]
    public int UserId { get; set; }

    [Required(ErrorMessage = "O RoleId não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O UserId não pode ser menor que 1.")]
    public int RoleId { get; set; }

    [Required(ErrorMessage = "O Discriminator não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O Discriminator deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O Discriminator deve ter no máximo 80 caracteres.")]
    public string Discriminator { get; set; }

}

