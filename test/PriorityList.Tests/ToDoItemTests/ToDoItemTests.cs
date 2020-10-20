using MediatR;
using Moq;
using NUnit.Framework;
using PriorityList.Application.Handler.Commands;
using PriorityList.Application.Messages.Commands;
using PriorityList.Domain.Entity;
using PriorityList.Domain.Repository;
using PriorityList.Domain.Repository.Common;
using PriorityList.Tests.TestTheoryData;
using PriorityList.Tests.TheoryModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace PriorityList.Tests.ToDoItemTests
{
    public class ToDoItemTests
    {
        //Mock
        private readonly Mock<IToDoItemRepository> _iToDoItemRepository = new Mock<IToDoItemRepository>();
        private readonly Mock<IApplicationDbContext> _iApplicationDbContext = new Mock<IApplicationDbContext>();

        private CreateToDoItemCommandHandler _createToDoItemHandler;
        private UpdateToDoItemCommandHandler _updateToDoItemCommandHandler;

        [SetUp]
        public void Setup()
        {
            // IToDoItemRepository.Setup(s=>s.Add())
            _iApplicationDbContext.Setup(s => s.SaveChangesAsync(new CancellationToken()));
            _createToDoItemHandler = new CreateToDoItemCommandHandler
                (
                    _iToDoItemRepository.Object,
                    _iApplicationDbContext.Object
                );

            _updateToDoItemCommandHandler = new UpdateToDoItemCommandHandler
                (
                    _iToDoItemRepository.Object,
                    _iApplicationDbContext.Object
                );
        }

        [Test]
        public void CreateToDoItem_StandartBehaviour_ExcpectUnitValue()
        {
            //arrange
            _iToDoItemRepository.Setup(s => s.LastPriorityNumber()).Returns(1);

            //act
            var result = _createToDoItemHandler.Handle(new CreateToDoItemCommand { }, new CancellationToken());

            //assert
            Assert.AreEqual(result, Unit.Value);
        }

        [Test]
        [TestCaseSource(typeof(UpdateToDoItemData), nameof(UpdateToDoItemData.SwapWithNextItem))]
        public void UpdateToDoItem_CheckChangeValueByOnePriorityNumber_ExcpectUnitValue
            (UpdateToDoItemCommand request, ToDoItem currentItem, ToDoItem nextItem)
        {
            //arrange
           
            _iToDoItemRepository.Setup(s => s.GetAsync(request.Id))
                .ReturnsAsync(currentItem);

            _iToDoItemRepository.Setup(s => s.Get(p => p.PriorityNumber.Equals(request.PriorityNumber)))
                .Returns((new List<ToDoItem>() { nextItem }).AsQueryable());

            //act
            var result = _updateToDoItemCommandHandler.Handle(request, new CancellationToken());

            //assert
            Assert.AreEqual(result, Unit.Value);
        }


    }
}
