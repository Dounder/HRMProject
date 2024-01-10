using HRM.Domain.Entities;
using HRM.Domain.Entities.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Data.Seed;

public static class UserSeed
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        var roles = new List<UserRole>
        {
            new() { Id = 1, Name = "Admin", NormalizedName = "ADMIN" },
            new() { Id = 2, Name = "User", NormalizedName = "USER" },
            new() { Id = 3, Name = "Guest", NormalizedName = "GUEST" }
        };

        modelBuilder.Entity<UserRole>().HasData(roles);

        var users = new List<User>
        {
            new()
            {
                Id = 1,
                UserName = "admin",
                NormalizedUserName = "ADMIN",
                Email = "admin@admin.com",
                PasswordHash = new PasswordHasher<User>().HashPassword(new User { Id = 1 }, "Admin@1234"),
                RefreshToken = Guid.NewGuid().ToString(),
                RefreshTokenExpiryTime = DateTime.UtcNow.AddDays(-1),
                SecurityStamp = Guid.NewGuid().ToString()
            }
        };

        modelBuilder.Entity<User>().HasData(users);

        var userRoles = new List<IdentityUserRole<int>>
        {
            new() { UserId = 1, RoleId = 1 },
            new() { UserId = 1, RoleId = 2 },
            new() { UserId = 1, RoleId = 3 }
        };

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);
    }
}