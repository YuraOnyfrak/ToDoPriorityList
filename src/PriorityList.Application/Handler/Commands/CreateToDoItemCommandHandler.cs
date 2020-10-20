using MediatR;
using PriorityList.Application.Messages.Commands;
using PriorityList.Domain.Repository;
using PriorityList.Domain.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriorityList.Application.Handler.Commands
{
    public class CreateToDoItemCommandHandler : IRequestHandler<CreateToDoItemCommand, Unit>
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public CreateToDoItemCommandHandler
            (
            IToDoItemRepository toDoItemRepository,
            IApplicationDbContext applicationDbContext
            )
        {
            _toDoItemRepository = toDoItemRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async  Task<Unit> Handle(CreateToDoItemCommand request, CancellationToken cancellationToken)
        {
            int priorityNumber = _toDoItemRepository.LastPriorityNumber();

            _toDoItemRepository.Add(new Domain.Entity.ToDoItem
            {
                Description = request.Description,
                PriorityNumber = priorityNumber + 1
            });
            await _applicationDbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
