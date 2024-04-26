using Application.Interfaces;
using Domain.Models;
using MediatR;

namespace Application.Features.Quizs.Update
{
    public class UpdateQuizCommandHandler : IRequestHandler<UpdateQuizCommand, int>
    {
            private readonly IApplicationDbContext _context;

            public UpdateQuizCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<int> Handle(UpdateQuizCommand request, CancellationToken cancellationToken)
            {
                var quiz = await _context.Quizs.FindAsync(request.Id, cancellationToken);

                quiz = new Quiz
                {
                    Id = request.Id,
                    Question = request.Question,
                    CorrectAnswer = request.CorrectAnswer,
                    WrongAnswer1 = request.WrongAnswer1,
                    WrongAnswer2 = request.WrongAnswer2,
                    WrongAnswer3 = request.WrongAnswer3
                };

                await _context.SaveChangeAsync(cancellationToken);
                return quiz.Id;
            }
        }
}
