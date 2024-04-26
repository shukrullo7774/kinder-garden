using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Persistance.EntityTypeConfiguration
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasKey(t => t.UserId);

            builder.Property(t => t.Firstame)
                .IsRequired();

            builder.Property(t => t.Lastname)
                .IsRequired();

            builder.Property(t => t.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(t => t.Login)
                .IsUnique();

            builder.Property(t => t.Password)
                .IsRequired() 
                .HasMaxLength(12);

        }
    }
}
