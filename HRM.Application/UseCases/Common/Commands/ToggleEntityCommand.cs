using HRM.Domain.Enums;
using HRM.Domain.Interfaces.Common;
using MediatR;

namespace HRM.Application.UseCases.Common.Commands;

public class ToggleEntityCommand<T> : IRequest<StatusType> where T : class, IBaseEntity
{
    public int Id { get; set; }
}