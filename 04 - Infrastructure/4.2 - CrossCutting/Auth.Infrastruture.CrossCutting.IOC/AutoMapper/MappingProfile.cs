using Auth.App.Dto;
using Auth.App.Dto.Auth;
using Auth.App.Dto.Identity;
using Auth.App.Dto.Menssage;
using Auth.App.Dto.Role;
using Auth.App.Dto.User;
using Auth.App.Dto.UserRole;
using Auth.App.Request.Auth;
using Auth.App.Request.User;
using Auth.App.Request.UserRole;
using Auth.App.Response.Roles;
using Auth.Domain.Entities.Identity;
using Auth.Domain.Entities.Mock;
using Auth.Domain.Entities.Users;
using Auth.Domain.Model;
using Auth.Domain.View.User;
using AutoMapper;

namespace Auth.Infrastruture.CrossCutting.IOC.AutoMapper;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        #region outros
        CreateMap<PageDto, PageModel>().ReverseMap();
        #endregion outros

        #region Auth
        CreateMap<LoginRequest, LoginDto>().ReverseMap();
        CreateMap<GenerateCodeResetRequest, GenerateCodeResetDto>().ReverseMap();


        CreateMap<TwilioDto, SendManssageMock>().ReverseMap();
        CreateMap<SendManssageMock, TwilioDto>().ReverseMap();

        CreateMap<SendGridDto, SendManssageMock>().ReverseMap();
        CreateMap<SendManssageMock, SendGridDto>().ReverseMap();

        CreateMap<ValidateCodeResetDto, UserCodeReset>().ReverseMap();
        CreateMap<UserCodeReset, ValidateCodeResetDto>().ReverseMap();
        #endregion Auth  

        #region Identity

        // Roles
        CreateMap<RoleModel, RolesDto>().ReverseMap();
        CreateMap<Role, RolesDto>().ReverseMap();
        CreateMap<RolesDto, RoleModel>().ReverseMap();
        CreateMap<CreateRolesRequest, RolesDto>().ReverseMap();
        CreateMap<UpdateRolesRequest, RolesDto>().ReverseMap();
        CreateMap<GetByIdRolesResponse, RolesDto>().ReverseMap();

        // User
        CreateMap<UserModel, UserListDto>().ReverseMap();
        CreateMap<UserModel, UserCreateDto>().ReverseMap();
        CreateMap<UserModel, UserUpdateDto>().ReverseMap();
        CreateMap<UserModel, UserUpdatePasswordDto>().ReverseMap();

        // UserRole
        CreateMap<UserRole, CreateUserRoleDto>().ReverseMap();
        CreateMap<CreateUserRoleDto, UserRole>().ReverseMap();
        CreateMap<CreateUserRoleRequest, CreateUserRoleDto>().ReverseMap();

        CreateMap<UserRole, UserRoleDto>().ReverseMap();
        CreateMap<UserRoleDto, UserRole>().ReverseMap();

        CreateMap<UserRoleRequest, UserRoleDto>().ReverseMap();
        CreateMap<GetUserRoleRequest, UserRoleDto>().ReverseMap();

        CreateMap<UserRoleDto, UserRoleRequest>().ReverseMap();

        // View
        CreateMap<ViewUserList, ViewUserListDto>().ReverseMap();
        CreateMap<ViewUserListDto, ViewUserList>().ReverseMap();

        CreateMap<User, UserUpdateDto>().ReverseMap();
        CreateMap<UserUpdateDto, User>().ReverseMap();

        CreateMap<UserListDto, UserModel>().ReverseMap();
        CreateMap<UserCreateDto, UserModel>().ReverseMap();
        CreateMap<UserUpdateDto, UserModel>().ReverseMap();
        CreateMap<UserUpdatePasswordDto, UserModel>().ReverseMap();

        CreateMap<CreateUserRequest, UserCreateDto>().ReverseMap();
        CreateMap<UpdateUserRequest, UserUpdateDto>().ReverseMap();
        CreateMap<UpdatePasswordUserRequest, UserUpdatePasswordDto>().ReverseMap();
        //CreateMap<GetByIdUserResponse, UserDto>().ReverseMap();

        #endregion Identity  
    }
}
