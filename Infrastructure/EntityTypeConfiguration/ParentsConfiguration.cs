using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Models;


namespace Persistance.EntityTypeConfiguration
{
    internal class ParentsConfiguration : IEntityTypeConfiguration<Parent>
    {
        public void Configure(EntityTypeBuilder<Parent> builder)
        {
            builder.HasKey(p => p.UserId);

            builder.Property(p => p.Firstame)
                .IsRequired();

            builder.Property(p => p.Lastname)
                .IsRequired();

            builder.Property(p => p.PhoneNumber)
                .IsRequired()
                .HasMaxLength(10);

            builder.Property(p => p.TelegramNick)
                .IsRequired()
                .HasMaxLength(25);

        }
    }
}
