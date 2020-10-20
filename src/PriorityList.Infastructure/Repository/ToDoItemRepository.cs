using PriorityList.Domain.Entity;
using PriorityList.Domain.Repository;
using PriorityList.Infastructure.Persistance;
using PriorityList.Infastructure.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PriorityList.Infastructure.Repository
{
    public class ToDoItemRepository : GenericRepository<ToDoItem>, IToDoItemRepository
    {
        public ToDoItemRepository(ApplicationDbContext context) : base(context)
        {
        }

        public int LastPriorityNumber()
        {
            return Context.ToDoItems.Max(s=>s.PriorityNumber);
        }
    }
}
