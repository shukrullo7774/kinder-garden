using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Parents.UpdateParent
{
    public class UpdateParentCommand : IRequest<int>
    {
        public int UserId { get; set; }
        public string Firsname { get; set; }
        public string Lastname { get; set; }
        public string PhoneNumber { get; set; }
        public string? TelegramNick { get; set; }
    }
}
