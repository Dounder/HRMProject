using HRM.Application.UseCases.Users.Services;
using HRM.Domain.Entities;
using HRM.Domain.Entities.Users;
using HRM.Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace HRM.Application.UseCases.Users.Commands;

public class DeleteUserCommandHandler(UserManager<User> userManager, UserService userService) : IRequestHandler<DeleteUserCommand, Unit>
{
    public async Task<Unit> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userService.GetByIdAsync(request.Id, withDeleted: true, cancellationToken);

        if (user.DeletedAt != null) throw new BadRequestException($"User is already inactive");

        user.DeletedAt = DateTime.UtcNow;

        var result = await userManager.UpdateAsync(user);

        if (!result.Succeeded) throw new BadRequestException($"Failed to set user as inactive");

        return Unit.Value;
    }
}