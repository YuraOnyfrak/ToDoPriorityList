using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityList.Application.DTO
{
    public class ToDoItemDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int PriorityNumber { get; set; }
    }
}
