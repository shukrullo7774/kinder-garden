using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.Schedules.Create
{
    public class CreateScheduleCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int LessonId { get; set; }
        public int GroupId { get; set; }
        public int TeacherId { get; set; }
        public DayOfWeek DayOfWeek { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}
