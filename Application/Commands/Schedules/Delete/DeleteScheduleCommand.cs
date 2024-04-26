using MediatR;

namespace Application.Features.Schedules.Delete
{
    public class DeleteScheduleCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
