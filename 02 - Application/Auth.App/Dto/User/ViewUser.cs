namespace Auth.App.Dto.User;

public class ViewUserListDto : BaseEntityDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string FileName { get; set; }
}
