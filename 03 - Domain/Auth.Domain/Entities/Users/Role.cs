using Auth.Domain.Validators;
using Auth.Infrastruture.CrossCutting.Exceptions;

namespace Auth.Domain.Entities.Users;

public class Role : BaseEntity
{
    public Role()
    {

    }
    public Role(string name, string normalizedName, string concurrencyStamp)
    {
        Name = name;
        NormalizedName = normalizedName;
        ConcurrencyStamp = concurrencyStamp;
    }

    public string Name { get; set; }
    public string NormalizedName { get; set; }
    public string ConcurrencyStamp { get; set; }

    public override bool Validate()
    {
        var validator = new RoleValidator();
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
