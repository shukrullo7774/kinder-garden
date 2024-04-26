using Application.Interfaces;
using Application.Common.Exceptions;
using MediatR;

namespace Application.Commands.Groups.DeleteGroup
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteGroupCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _context.Groups.FindAsync(request.Id);
            if (group == null)
            {
                throw new NotFoundException(nameof(group), request.Id);
            }

            _context.Groups.Remove(group);
            await _context.SaveChangeAsync(cancellationToken);
            return group.Id;
        }
    }
}
