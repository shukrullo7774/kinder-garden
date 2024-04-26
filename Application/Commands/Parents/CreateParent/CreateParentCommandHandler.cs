using Application.Interfaces;
using MediatR;
using Domain.Models;

namespace Application.Features.Parents.CreateParent
{
    public class CreateParentCommandHandler : IRequestHandler<CreateParentCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateParentCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateParentCommand request, CancellationToken cancellationToken)
        {
            var parent = new Parent
            {
                UserId = request.UserId,
                Firstame = request.Firsname,
                Lastname = request.Lastname,
                PhoneNumber = request.PhoneNumber,
                TelegramNick = request.TelegramNick
            };

            _context.Parents.Add(parent);
            await _context.SaveChangeAsync(cancellationToken);
            return parent.UserId;
        }
    }
}
