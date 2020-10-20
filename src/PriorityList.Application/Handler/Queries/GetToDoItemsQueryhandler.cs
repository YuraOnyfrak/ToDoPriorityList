using MediatR;
using Microsoft.EntityFrameworkCore;
using PriorityList.Application.DTO;
using PriorityList.Application.Messages.Queries;
using PriorityList.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriorityList.Application.Handler.Queries
{
    public class GetToDoItemsQueryHandler : IRequestHandler<GetToDoItemsQuery, IEnumerable<ToDoItemDto>>
    {
        private readonly IToDoItemRepository _toDoItemRepository;

        public GetToDoItemsQueryHandler(IToDoItemRepository toDoItemRepository)
        {
            this._toDoItemRepository = toDoItemRepository;
        }

        public async Task<IEnumerable<ToDoItemDto>> Handle(GetToDoItemsQuery request, CancellationToken cancellationToken)
        {
            return await _toDoItemRepository.Get().Select(s => new ToDoItemDto
            {
                Id = s.Id,
                Description = s.Description,
                PriorityNumber = s.PriorityNumber
            }).ToListAsync();

        }
    }
}
