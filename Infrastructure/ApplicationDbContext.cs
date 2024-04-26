using Domain.Models;
using Application.Interfaces;
using Infrastructure.EntityTypeConfiguration;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityTypeConfiguration;


namespace Persistance
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        DbSet<Group> IApplicationDbContext.Groups { get; set; }
        DbSet<Lesson> IApplicationDbContext.Lessons { get; set; }
        DbSet<Parent> IApplicationDbContext.Parents { get; set; }
        DbSet<Quiz> IApplicationDbContext.Quizs { get; set; }
        DbSet<Schedule> IApplicationDbContext.Schedules { get; set; }
        DbSet<Student> IApplicationDbContext.Students { get; set; }
        DbSet<Teacher> IApplicationDbContext.Teachers { get; set; }

        public ApplicationDbContext(DbContextOptions<DbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new GroupConfiguration());
            builder.ApplyConfiguration(new LessonsConfiguration());
            builder.ApplyConfiguration(new ParentsConfiguration());
            builder.ApplyConfiguration(new QuizConfiguration());
            builder.ApplyConfiguration(new ScheduleConfiguration());
            builder.ApplyConfiguration(new StudentConfiguration());
            builder.ApplyConfiguration(new TeacherConfiguration());

            base.OnModelCreating(builder);
        }

        public async Task<int> SaveChangeAsync(CancellationToken cancellationToken)
        {
            return await SaveChangesAsync(cancellationToken);
        }

    }
}
