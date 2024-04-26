using Application.Commands.Groups.DeleteGroup;
using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Schedules.Delete
{
    public class DeleteScheduleCommandHandler : IRequestHandler<DeleteScheduleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteScheduleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<int> Handle(DeleteScheduleCommand request, CancellationToken cancellationToken)
        {
            var schedule = await _context.Schedules.FindAsync(request.Id);
            if (schedule == null)
            {
                throw new NotFoundException(nameof(schedule), request.Id);
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangeAsync(cancellationToken);
            return schedule.Id;
        }
    }
}
