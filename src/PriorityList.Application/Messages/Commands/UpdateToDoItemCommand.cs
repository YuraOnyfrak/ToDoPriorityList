using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityList.Application.Messages.Commands
{
    public class UpdateToDoItemCommand : IRequest
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PriorityNumber { get; set; }
    }
}
