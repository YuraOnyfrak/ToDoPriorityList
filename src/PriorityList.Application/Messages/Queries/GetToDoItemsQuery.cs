using MediatR;
using PriorityList.Application.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityList.Application.Messages.Queries
{
    public class GetToDoItemsQuery : IRequest<IEnumerable<ToDoItemDto>>
    {
    }
}
