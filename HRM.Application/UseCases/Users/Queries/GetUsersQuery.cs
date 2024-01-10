using HRM.Application.UseCases.Users.DTOs;
using HRM.Domain.Common;
using MediatR;

namespace HRM.Application.UseCases.Users.Queries;

public class GetUsersQuery(PaginationParams pagination) : IRequest<IEnumerable<UserDto>>
{
    public PaginationParams Pagination { get; set; } = pagination;
}