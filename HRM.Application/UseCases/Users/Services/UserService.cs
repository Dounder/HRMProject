using HRM.Application.UseCases.Users.DTOs;
using HRM.Domain.Entities;
using HRM.Domain.Entities.Users;
using HRM.Domain.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace HRM.Application.UseCases.Users.Services;

public class UserService(UserManager<User> userManager)
{
    public async Task<User> GetByIdAsync(int id, bool withDeleted = false, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByIdAsync(id.ToString());

        ValidateUser(user, withDeleted);

        return user!;
    }

    public async Task<User> GetByEmailAsync(string email, bool withDeleted = false, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByEmailAsync(email);

        ValidateUser(user);

        return user!;
    }

    public async Task<User> FindUserByNameAsync(string username, bool withDeleted = false, CancellationToken cancellationToken = default)
    {
        var user = await userManager.FindByNameAsync(username);

        ValidateUser(user);

        return user!;
    }

    private void ValidateUser(User? user, bool withDeleted = false)
    {
        if (user is null) throw new NotFoundException("User not found");

        if (!withDeleted && user.DeletedAt != null) throw new NotFoundException("User inactive, please contact your administrator");
    }
}