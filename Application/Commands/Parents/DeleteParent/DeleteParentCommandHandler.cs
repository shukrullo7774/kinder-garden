using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;

namespace Application.Features.Parents.DeleteParent
{
    public class DeleteParentCommandHandler : IRequestHandler<DeleteParentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteParentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteParentCommand request, CancellationToken cancellationToken)
        {
            var parent = await _context.Parents.FindAsync(request.UserId, cancellationToken);
            if (parent == null)
            {
                throw new NotFoundException(nameof(parent), request.UserId);
            }

            _context.Parents.Remove(parent);
            await _context.SaveChangeAsync(cancellationToken);
            return parent.UserId;
        }

    }
}
