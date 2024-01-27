using AutoMapper;
using HRM.Application.UseCases.Users.DTOs;
using HRM.Domain.Entities.Users;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Memory;

namespace HRM.Application.UseCases.Users.Services;

public class RoleService(UserManager<User> userManager, RoleManager<UserRole> roleManager, IMapper mapper, IMemoryCache cache, IUnitOfWork repository)
{
    public async Task AddRoleToUser(User user, List<string> roles)
    {
        foreach (var roleName in roles.Distinct())
        {
            var role = await roleManager.FindByNameAsync(roleName);
            if (role == null) throw new BadRequestException($"Role {roleName} does not exist");

            var result = await userManager.AddToRoleAsync(user, roleName);
            if (!result.Succeeded) throw new BadRequestException($"Failed to add role {roleName} to user");
        }
    }

    public async Task<IEnumerable<RoleDto>> GetAllRoles(int userId)
    {
        var cacheKey = $"UserRoles_{userId}";
        if (cache.TryGetValue(cacheKey, out IEnumerable<RoleDto>? roles)) return roles ?? Enumerable.Empty<RoleDto>();

        // Data not in cache, so load data.
        var rolesNames = await userManager.GetRolesAsync(new User { Id = userId });
        var rolesData = roleManager.Roles.Where(x => rolesNames.Contains(x.Name!));
        roles = mapper.Map<IEnumerable<RoleDto>>(rolesData);

        // Set cache options.
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromDays(1));

        // Save data in cache.
        var allRoles = roles.ToList();
        cache.Set(cacheKey, allRoles, cacheEntryOptions);

        return allRoles;
    }

    public async ValueTask UpdateRoles(User user, List<RoleDto> roles, CancellationToken cancellationToken = default)
    {
        if (roles.Count == 0) return;

        var newRoles = roles.Select(r => r.Name).ToList();
        var currentRoles = await userManager.GetRolesAsync(user);

        var removeRolesResult = await userManager.RemoveFromRolesAsync(user, currentRoles);
        if (!removeRolesResult.Succeeded) throw new BadRequestException("Error while updating user roles");

        var addRolesResult = await userManager.AddToRolesAsync(user, newRoles);
        if (!addRolesResult.Succeeded) throw new BadRequestException("Error while updating user roles");

        // Update cache
        var cacheKey = $"UserRoles_{user.Id}";
        var cacheEntryOptions = new MemoryCacheEntryOptions()
            .SetSlidingExpiration(TimeSpan.FromDays(1));
        cache.Set(cacheKey, roles, cacheEntryOptions);

        await repository.CommitAsync(cancellationToken);
    }
}