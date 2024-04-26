using Application.Commands.Groups.DeleteGroup;
using Application.Common.Exceptions;
using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Quizs.Delete
{
    public class DeleteQuizCommandHandler : IRequestHandler<DeleteQuizCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public DeleteQuizCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = await _context.Quizs.FindAsync(request.Id);
            if (quiz == null)
            {
                throw new NotFoundException(nameof(quiz), request.Id);
            }

            _context.Quizs.Remove(quiz);
            await _context.SaveChangeAsync(cancellationToken);
            return 0;
        }
    }
}
