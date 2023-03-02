using Auth.App.Dto;
using Auth.App.Dto.Identity;
using Auth.App.Dto.Role;
using Auth.App.Dto.UserRole;
using Auth.App.Request.UserRole;
using Auth.Domain.Entities.Users;
using Auth.Domain.Model;
using AutoMapper;

namespace Auth.Tests.Configurations.AutoMapper;


public static class AutoMapperConfiguration
{
    public static IMapper GetConfiguration()
    {
        var autoMapperConfig = new MapperConfiguration(cfg =>
        {
            #region outros
            cfg.CreateMap<PageDto, PageModel>().ReverseMap();
            #endregion outros


            #region Role
            cfg.CreateMap<Role, RolesDto>().ReverseMap();
            cfg.CreateMap<RolesDto, Role>().ReverseMap();

            cfg.CreateMap<CreateRolesRequest, RolesDto>().ReverseMap();
            cfg.CreateMap<UpdateRolesRequest, RolesDto>().ReverseMap();
            #endregion Role 

            #region UserRole

            cfg.CreateMap<UserRole, CreateUserRoleDto>().ReverseMap();
            cfg.CreateMap<CreateUserRoleDto, UserRole>().ReverseMap();
            cfg.CreateMap<CreateUserRoleRequest, CreateUserRoleDto>().ReverseMap();

            cfg.CreateMap<UserRole, UserRoleDto>().ReverseMap();
            cfg.CreateMap<UserRoleDto, UserRole>().ReverseMap();

            cfg.CreateMap<UserRoleRequest, UserRoleDto>().ReverseMap();
            cfg.CreateMap<GetUserRoleRequest, UserRoleDto>().ReverseMap();

            cfg.CreateMap<UserRoleDto, UserRoleRequest>().ReverseMap();
            #endregion UserRole
        });

        return autoMapperConfig.CreateMapper();
    }
}