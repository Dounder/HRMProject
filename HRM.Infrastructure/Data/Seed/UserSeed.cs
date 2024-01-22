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
            new() { Id = 1, Name = "Admin", NormalizedName = "ADMIN", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 2, Name = "User", NormalizedName = "USER", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 3, Name = "Guest", NormalizedName = "GUEST", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 4, Name = "Manager", NormalizedName = "MANAGER", CreatedAt = DateTime.Parse("2024-01-01") },
            new() { Id = 5, Name = "Employee", NormalizedName = "EMPLOYEE", CreatedAt = DateTime.Parse("2024-01-01") }
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
                PasswordHash = "AQAAAAIAAYagAAAAEJoCuIiPTpl+5UGRe6YdpBHiDhokwHeayGPUu6xxllAjyHGHcvrc5HXuxe7IY5cZtA==",
                RefreshToken = "a8edd57d-5a95-4bd5-a75b-07d2ffa6739e",
                RefreshTokenExpiryTime = DateTime.Parse("2024-01-01"),
                SecurityStamp = "72847254-bae2-46ab-b4d3-25e189ce531d",
                ConcurrencyStamp = "bcee7468-91cf-468d-bd6b-7fcd42ff2728"
            }
        };

        modelBuilder.Entity<User>().HasData(users);

        var userRoles = new List<IdentityUserRole<int>>
        {
            new() { UserId = 1, RoleId = 1 },
            new() { UserId = 1, RoleId = 2 },
            new() { UserId = 1, RoleId = 3 },
            new() { UserId = 1, RoleId = 4 },
            new() { UserId = 1, RoleId = 5 },
        };

        modelBuilder.Entity<IdentityUserRole<int>>().HasData(userRoles);
    }
}