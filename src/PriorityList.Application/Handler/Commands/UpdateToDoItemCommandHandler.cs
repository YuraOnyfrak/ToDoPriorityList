using EFCore.BulkExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PriorityList.Application.Messages.Commands;
using PriorityList.Domain.Entity;
using PriorityList.Domain.Repository;
using PriorityList.Domain.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace PriorityList.Application.Handler.Commands
{
    public class UpdateToDoItemCommandHandler : IRequestHandler<UpdateToDoItemCommand, Unit>
    {
        private readonly IToDoItemRepository _toDoItemRepository;
        private readonly IApplicationDbContext _applicationDbContext;

        public UpdateToDoItemCommandHandler
            (
            IToDoItemRepository toDoItemRepository,
            IApplicationDbContext applicationDbContext
            )
        {
            _toDoItemRepository = toDoItemRepository;
            _applicationDbContext = applicationDbContext;
        }

        public async Task<Unit> Handle(UpdateToDoItemCommand request, CancellationToken cancellationToken)
        {
            var currentToDoItem = await _toDoItemRepository.GetAsync(request.Id);

            int difference = currentToDoItem.PriorityNumber - request.PriorityNumber;
                        
            if(difference == 1)
            {
                var otherItem = _toDoItemRepository
                        .Get(s => s.PriorityNumber == currentToDoItem.PriorityNumber)
                        .FirstOrDefault();

                //swap
                int priorityCurrentitem = currentToDoItem.PriorityNumber;
                currentToDoItem.PriorityNumber = request.PriorityNumber;
                otherItem.PriorityNumber = priorityCurrentitem;

                await _applicationDbContext.SaveChangesAsync(cancellationToken);
            }            
            else 
            {
                var plusMinusOne = difference > 0 ? 1 : -1; 

                var itemsForUpdate = 
                    _toDoItemRepository.Get(s => s.PriorityNumber > currentToDoItem.PriorityNumber && 
                                            s.PriorityNumber < request.PriorityNumber)
                    .Select(s=> new ToDoItem
                    {
                        Id = s.Id,
                        Description = s.Description,
                        PriorityNumber = s.PriorityNumber + plusMinusOne
                    })
                    .ToList();

                (_toDoItemRepository.Context as DbContext).BulkUpdate(itemsForUpdate);
            }            

            return Unit.Value;
        }
    }
}
