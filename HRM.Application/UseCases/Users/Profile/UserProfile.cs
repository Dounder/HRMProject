using HRM.Application.UseCases.Auth.DTOs;
using HRM.Application.UseCases.Users.Commands;
using HRM.Application.UseCases.Users.DTOs;
using HRM.Domain.Entities.Users;

namespace HRM.Application.UseCases.Users.Profile;

public class UserProfile : AutoMapper.Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<User, AuthDto>();

        CreateMap<UpdateUserCommand, User>()
            .ForMember(dest => dest.Roles, opt => opt.Ignore())
            .ForAllMembers(opts => opts.Condition((_, _, srcMember) => srcMember != null));

        CreateMap<UserRole, RoleDto>();
    }
}