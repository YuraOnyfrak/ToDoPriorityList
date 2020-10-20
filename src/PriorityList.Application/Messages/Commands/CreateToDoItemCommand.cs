using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityList.Application.Messages.Commands
{
    public class CreateToDoItemCommand : IRequest
    {
        public string Description { get; set; }
    }
}
