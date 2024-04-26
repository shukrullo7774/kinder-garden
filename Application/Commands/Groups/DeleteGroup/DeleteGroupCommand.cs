using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Commands.Groups.DeleteGroup
{
    public class DeleteGroupCommand : IRequest<int>
    {
        public int Id { get; set; }
    }
}
