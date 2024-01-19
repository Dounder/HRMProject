using HRM.Domain.Entities.Employees;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HRM.Infrastructure.Data.Configs.Employees;

public class TimeTrackingConfig : IEntityTypeConfiguration<TimeTracking>
{
    public void Configure(EntityTypeBuilder<TimeTracking> builder)
    {
        builder.Property(x => x.TimeIn).HasColumnType("time").IsRequired();
        builder.Property(x => x.TimeOut).HasColumnType("time").IsRequired();
        builder.Property(x => x.TotalHours).HasPrecision(5, 2).IsRequired();
        builder.Property(x => x.TotalExtraHours).HasPrecision(5, 2).HasDefaultValue(0).IsRequired();
    }
}