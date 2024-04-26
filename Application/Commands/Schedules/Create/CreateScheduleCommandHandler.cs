using Application.Interfaces;
using MediatR;
using Domain.Models;

namespace Application.Features.Schedules.Create
{
    public class CreateScheduleCommandHandler : IRequestHandler<CreateScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = new Schedule
            {
                LessonId = request.LessonId,
                GroupId = request.GroupId,
                TeacherId = request.TeacherId,
                DayOfWeek = request.DayOfWeek,
                StartTime = request.StartTime,
                EndTime = request.EndTime,
            };

            _context.Schedules.Add(schedule);
            await _context.SaveChangeAsync(cancellationToken);

            return schedule.Id; 
        }
    }
}
