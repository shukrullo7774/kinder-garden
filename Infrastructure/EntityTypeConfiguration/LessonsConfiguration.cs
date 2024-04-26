using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;
using Domain.Enums;

namespace Infrastructure.EntityTypeConfiguration
{
    internal class LessonsConfiguration : IEntityTypeConfiguration<Lesson>
    {
        public void Configure(EntityTypeBuilder<Lesson> builder)
        {
            builder.HasKey(l => l.Id);

            builder.Property(l => l.LessonName)
                .IsRequired();

            builder.Property(l => l.Description)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(l => l.Category)
                .HasConversion<int>();

        }
    }
}
