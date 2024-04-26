using Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Parents.DeleteParent
{
    public class DeleteParentCommand : IRequest<int>
    {
        public int UserId { get; set; }
    }
}
