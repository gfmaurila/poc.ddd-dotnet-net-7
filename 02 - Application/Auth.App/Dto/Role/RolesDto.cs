namespace Auth.App.Dto.Role;


#region Role / Create / Update / Listagem
public class RolesDto : BaseEntityDto
{
    public RolesDto()
    {

    }

    public RolesDto(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}
#endregion

