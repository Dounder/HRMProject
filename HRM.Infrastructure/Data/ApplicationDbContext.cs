using HRM.Domain.Entities;
using HRM.Domain.Entities.Employees;
using HRM.Domain.Entities.Users;
using HRM.Infrastructure.Data.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HRM.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
    : IdentityDbContext<User, UserRole, int>(options)
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
        SeedManager.Seed(modelBuilder);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.EnableSensitiveDataLogging();
        optionsBuilder.UseSqlServer(configuration.GetConnectionString("DefaultConnection"))
            .LogTo(Console.WriteLine, LogLevel.Information);
    }

    #region Users

    public override DbSet<User> Users { get; set; } = null!;
    public override DbSet<UserRole> Roles { get; set; } = null!;

    #endregion

    #region Employee

    public DbSet<Employee> Employees { get; set; } = null!;
    public DbSet<TimeTracking> TimeTrackings { get; set; } = null!;
    public DbSet<Position> Positions { get; set; } = null!;
    public DbSet<Department> Departments { get; set; } = null!;

    #endregion
}