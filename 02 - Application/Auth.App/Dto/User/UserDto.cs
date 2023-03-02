using System.ComponentModel.DataAnnotations;

namespace Auth.App.Dto.User;

#region User / Create
public class UserCreateDto
{
    public UserCreateDto()
    {

    }
    public UserCreateDto(string name, string phoneNumber, string email, string userName, string password, string confirmPassword, bool status)
    {
        Name = name;
        PhoneNumber = phoneNumber;
        Email = email;
        UserName = userName;
        Password = password;
        ConfirmPassword = confirmPassword;
        Status = status;
    }

    public string Name { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string ConfirmPassword { get; set; }
    public bool Status { get; set; }
}
#endregion

#region Update
public class UserUpdateDto
{
    public UserUpdateDto()
    {

    }

    public UserUpdateDto(int id, string phoneNumber, string email, bool status)
    {
        Id = id;
        PhoneNumber = phoneNumber;
        Email = email;
        Status = status;
    }

    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public bool Status { get; set; }
}
#endregion

#region Update Password
public class UserUpdatePasswordDto
{
    public UserUpdatePasswordDto()
    {

    }

    public UserUpdatePasswordDto(int id, string newPassword)
    {
        Id = id;
        NewPassword = newPassword;
    }

    public int Id { get; set; }
    public string NewPassword { get; set; }
    public string UserName { get; set; }
}
#endregion

#region Listagem
public class UserListDto
{
    public UserListDto()
    {

    }

    public UserListDto(int id, string phoneNumber, string email, string userName, bool status)
    {
        Id = id;
        PhoneNumber = phoneNumber;
        Email = email;
        UserName = userName;
        Status = status;
    }

    public int Id { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string UserName { get; set; }
    public bool Status { get; set; }
}
#endregion