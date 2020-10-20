using NUnit.Framework;
using PriorityList.Application.Messages.Commands;
using PriorityList.Domain.Entity;
using PriorityList.Tests.TheoryModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace PriorityList.Tests.TestTheoryData
{
    public static class UpdateToDoItemData
    {
        public static TestCaseData SwapWithNextItem()
        {
            return new TestCaseData
            (
                new UpdateToDoItemCommand // input data
                {
                    Id = 1,
                    PriorityNumber = 2
                },
                new ToDoItem // current item
                {
                    Id = 1,
                    PriorityNumber = 1,
                },
                new ToDoItem // item to swap(next)
                {
                    Id = 2,
                    PriorityNumber = 2
                } 
                
            );
        }
    }
}
