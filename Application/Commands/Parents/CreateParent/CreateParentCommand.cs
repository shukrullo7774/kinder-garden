using MediatR;

namespace Application.Features.Parents.CreateParent
{
    public class CreateParentCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Firsname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string? TelegramNick { get; set; }
    }
}
