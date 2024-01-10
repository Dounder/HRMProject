using System.ComponentModel.DataAnnotations;
using HRM.Domain.Interfaces.Common;
using Microsoft.AspNetCore.Identity;

namespace HRM.Domain.Entities.Users;

public class User : IdentityUser<int>, IBaseEntity
{
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public List<UserRole> Roles { get; set; } = new();

    // RefreshToken
    [MaxLength(1000)] public string RefreshToken { get; set; } = default!;
    public DateTime RefreshTokenExpiryTime { get; set; } = default!;
}