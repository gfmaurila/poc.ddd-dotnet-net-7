using Auth.Domain.Validators;
using Auth.Infrastruture.CrossCutting.Exceptions;

namespace Auth.Domain.Entities.Users;

public class UserRole : BaseEntity
{
    public UserRole()
    {

    }

    public UserRole(int userId, int roleId, string discriminator)
    {
        UserId = userId;
        RoleId = roleId;
        Discriminator = discriminator;
    }

    public int UserId { get; set; }
    public User User { get; set; }
    public int RoleId { get; set; }
    public Role Role { get; set; }
    public string Discriminator { get; set; }

    public override bool Validate()
    {
        var validator = new UserRoleValidator();
        var validation = validator.Validate(this);

        if (!validation.IsValid)
        {
            foreach (var error in validation.Errors)
                _errors.Add(error.ErrorMessage);

            throw new Exceptions("Alguns campos estão inválidos, por favor corrija-os!", _errors);
        }

        return true;
    }
}
