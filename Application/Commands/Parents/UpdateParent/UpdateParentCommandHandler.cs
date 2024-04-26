using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Parents.UpdateParent
{
    public class UpdateParentCommandHandler : IRequestHandler<UpdateParentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public UpdateParentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateParentCommand request, CancellationToken cancellationToken)
        {
            var parent = await _context.Parents.FindAsync(request.UserId, cancellationToken);

            parent = new Parent
            {
                UserId = request.UserId,
                Firstame = request.Firsname,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                TelegramNick = request.TelegramNick
            };

            await _context.SaveChangeAsync(cancellationToken);
            return parent.UserId;
        }
    }
}
