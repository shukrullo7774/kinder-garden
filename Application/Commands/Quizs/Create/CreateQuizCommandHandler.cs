using Application.Interfaces;
using MediatR;
using Domain.Models;

namespace Application.Features.Quizs.Create
{
    public class CreateQuizCommandHandler : IRequestHandler<CreateQuizCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateQuizCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateQuizCommand request, CancellationToken cancellationToken)
        {
            var quiz = new Quiz
            {
                Question = request.Question,
                CorrectAnswer = request.CorrectAnswer,
                WrongAnswer1 = request.WrongAnswer1,
                WrongAnswer2 = request.WrongAnswer2,
                WrongAnswer3 = request.WrongAnswer3,
            };

            _context.Quizs.Add(quiz);
            await _context.SaveChangeAsync(cancellationToken);

            return quiz.Id;
        }
    }
}
