using System.ComponentModel.DataAnnotations;

namespace Auth.App.Dto.Identity;

#region Create
public class CreateRolesRequest
{
    public CreateRolesRequest()
    {

    }

    public CreateRolesRequest(string name)
    {
        Name = name;
    }

    public bool Status { get; set; }

    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string Name { get; set; }
}
#endregion

#region Update
public class UpdateRolesRequest
{
    public UpdateRolesRequest(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public UpdateRolesRequest()
    {

    }

    [Required(ErrorMessage = "O Id não pode ser vazio.")]
    [Range(1, int.MaxValue, ErrorMessage = "O Id não pode ser menor que 1.")]
    public int Id { get; set; }

    public bool Status { get; set; }

    [Required(ErrorMessage = "O nome não pode ser vazio.")]
    [MinLength(3, ErrorMessage = "O nome deve ter no mínimo 3 caracteres.")]
    [MaxLength(80, ErrorMessage = "O nome deve ter no máximo 80 caracteres.")]
    public string Name { get; set; }
}
#endregion
