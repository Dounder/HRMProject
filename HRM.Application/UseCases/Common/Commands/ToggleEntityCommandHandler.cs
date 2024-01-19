using HRM.Domain.Enums;
using HRM.Domain.Exceptions;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Common.Commands;

public class ToggleEntityCommandHandler<T>(IUnitOfWork repository) : IRequestHandler<ToggleEntityCommand<T>, StatusType> where T : class, IBaseEntity
{
    public async Task<StatusType> Handle(ToggleEntityCommand<T> request, CancellationToken cancellationToken)
    {
        var result = await repository.Toggle.ToggleAsync<T>(request.Id, cancellationToken);

        if (result == StatusType.NotFound) throw new NotFoundException("Entity not found");

        return result;
    }
}