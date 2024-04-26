using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfiguration
{
    internal class QuizConfiguration : IEntityTypeConfiguration<Quiz>
    {
        public void Configure(EntityTypeBuilder<Quiz> builder) 
        {
            builder.HasKey(q => q.Id);

            builder.Property(q => q.Question)
                .IsRequired();

            builder.Property(q => q.CorrectAnswer)
                .IsRequired();

            builder.Property(q => q.WrongAnswer1)
                .IsRequired();

            builder.Property(q => q.WrongAnswer2)
                .IsRequired();

            builder.Property(q => q.WrongAnswer3)
                .IsRequired();


        }
    }
}
