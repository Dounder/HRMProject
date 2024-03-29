using MediatR;

namespace HRM.Application.UseCases.Users.Commands;

public class RestoreUserCommand(int id) : IRequest<Unit>
{
    public int Id { get; set; } = id;
}