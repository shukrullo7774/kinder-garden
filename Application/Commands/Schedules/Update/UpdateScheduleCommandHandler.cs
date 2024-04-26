using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Schedules.Update
{
    public class UpdateScheduleCommandHandler : IRequestHandler<UpdateScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateScheduleCommandHandler(IApplicationDbContext  context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _context.Schedules.FindAsync(request.Id);

            if (schedule == null)
            {
                throw new NotFoundException(nameof(schedule), request.Id);
            }
            schedule.LessonId = request.LessonId;
            schedule.GroupId = request.GroupId;
            schedule.TeacherId = request.TeacherId;
            schedule.DayOfWeek = request.DayOfWeek;
            schedule.StartTime = request.StartTime;
            schedule.EndTime = request.EndTime;

            _context.Schedules.Update(schedule);
            await _context.SaveChangeAsync(cancellationToken);

            return schedule.Id;
        }
    }
}
