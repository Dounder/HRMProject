using HRM.Domain.Entities.Trackings;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Infrastructure.Data.Configs.Trackings;

public class TimeTrackingConfig : IEntityTypeConfiguration<TimeTracking>
{
    public void Configure(EntityTypeBuilder<TimeTracking> builder)
    {
        builder.HasIndex(x => new { x.EmployeeId, x.Date }).IsUnique();

        builder.Property(x => x.TimeIn).HasColumnType("time").IsRequired();
        builder.Property(x => x.TimeOut).HasColumnType("time");
        builder.Property(x => x.LunchOut).HasColumnType("time");
        builder.Property(x => x.LunchIn).HasColumnType("time");
        builder.Property(x => x.TotalHours).HasPrecision(5, 2).HasDefaultValue(0).IsRequired();
        builder.Property(x => x.TotalExtraHours).HasPrecision(5, 2).HasDefaultValue(0).IsRequired();
        builder.Property(x => x.Date).HasColumnType("date").HasDefaultValueSql("getdate()").IsRequired();

        builder.HasOne(x => x.Employee)
            .WithMany(x => x.TimeTrackings)
            .HasForeignKey(x => x.EmployeeId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}