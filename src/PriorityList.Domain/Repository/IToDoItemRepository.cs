using PriorityList.Domain.Entity;
using PriorityList.Domain.Repository.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityList.Domain.Repository
{
    public interface IToDoItemRepository : IGenericRepository<ToDoItem>
    {
        int LastPriorityNumber();
    }
}
