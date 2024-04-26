using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;

namespace Persistance.EntityTypeConfiguration
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasKey(s => s.UserId);

            builder.Property(s => s.Firstame)
                .IsRequired();

            builder.Property(s => s.Lastname)
                .IsRequired();

            builder.Property(s => s.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.HasIndex(s => s.Login)
                .IsUnique();

            builder.Property(s => s.Password)
                .IsRequired()
                .HasMaxLength(12);
            
        }
    }
}
