using Microsoft.EntityFrameworkCore;

namespace HRM.Infrastructure.Data.Seed;

public static class SeedManager
{
    public static void Seed(ModelBuilder modelBuilder)
    {
        UserSeed.Seed(modelBuilder);
    }
}