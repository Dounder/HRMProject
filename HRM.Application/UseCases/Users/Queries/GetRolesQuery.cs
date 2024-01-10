using HRM.Application.UseCases.Users.DTOs;
using HRM.Domain.Common;
using MediatR;

namespace HRM.Application.UseCases.Users.Queries;

public class GetRolesQuery(PaginationParams paginationParams) : IRequest<List<RoleDto>>
{
    public PaginationParams PaginationParams { get; } = paginationParams;
}