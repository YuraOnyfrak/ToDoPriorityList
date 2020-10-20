using PriorityList.Domain.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityList.Domain.Entity
{
    public class ToDoItem : Identifiable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PriorityNumber { get; set; }
    }
}
