using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;

namespace Persistance.EntityTypeConfiguration
{
    public class ScheduleConfiguration : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(sch => sch.Id);

            builder.Property(sch => sch.StartTime)
                .IsRequired();

            builder.Property(sch => sch.EndTime)
                .IsRequired();
        }
    }
}
