using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Group> Groups { get; set; }
        DbSet<Lesson> Lessons { get; set; }
        DbSet<Parent> Parents { get; set; }
        DbSet<Quiz> Quizs { get; set; }
        DbSet<Schedule> Schedules { get; set; }
        DbSet<Student> Students { get; set; }
        DbSet<Teacher> Teachers { get; set; }

        Task<int> SaveChangeAsync(CancellationToken cancellationToken);
    }
}
