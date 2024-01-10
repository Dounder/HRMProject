using HRM.Domain.Interfaces.Common;
using Microsoft.AspNetCore.Identity;

namespace HRM.Domain.Entities.Users;

public class UserRole : IdentityRole<int>, IBaseEntity
{
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
}