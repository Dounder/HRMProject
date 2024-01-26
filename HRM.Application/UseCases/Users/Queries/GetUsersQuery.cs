using HRM.Application.UseCases.Users.DTOs;
using HRM.Domain.Common;
using MediatR;

namespace HRM.Application.UseCases.Users.Queries;

public class GetUsersQuery(PaginationParams pagination, bool isAdmin = false) : IRequest<IEnumerable<UserDto>>
{
    public PaginationParams Pagination { get; set; } = pagination;
    public bool IsAdmin { get; set; } = isAdmin;
}