using Application.Interfaces;
using MediatR;
using Domain.Models;
using System.Threading.Tasks.Dataflow;
using Application.Common.Exceptions;


namespace Application.Commands.Groups.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups.FindAsync(request.Id, cancellationToken);

            if (group == null)
            {
                throw new NotFoundException(nameof(group), request.Id);
            }

            group.GroupName = request.GroupName.ToString();

            if (request.Students != null && request.Students.Any())
            {
                group.Students?.Clear();

                foreach (var student in request.Students)
                {
                    group.Students?.Add(student);
                }
            }

            
            await _context.SaveChangeAsync(cancellationToken);

            return group.Id;
        }
    }
}
