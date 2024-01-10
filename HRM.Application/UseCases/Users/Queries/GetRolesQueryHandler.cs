using HRM.Application.UseCases.Users.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Entities.Users;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRM.Application.UseCases.Users.Queries;

public class GetRolesQueryHandler(RoleManager<UserRole> roleManager) : IRequestHandler<GetRolesQuery, List<RoleDto>>
{
    public Task<List<RoleDto>> Handle(GetRolesQuery request, CancellationToken cancellationToken)
    {
        var roles = roleManager.Roles.Select(r => new RoleDto
        {
            Id = r.Id,
            Name = r.Name ?? string.Empty,
        }).Skip(request.PaginationParams.Offset).Take(request.PaginationParams.Limit).ToList();

        return Task.FromResult(roles);
    }
}