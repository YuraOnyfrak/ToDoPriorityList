using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using PriorityList.Application.DTO;
using PriorityList.Application.Messages.Commands;
using PriorityList.Application.Messages.Queries;

namespace PriorityList.Api.Controllers
{
    public class ToDoItemController : Controller
    {
        private readonly IMediator _mediator;

        public ToDoItemController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        // <summary>
        /// Create to do item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPost("create")]
        public async Task<ActionResult> Create([FromBody]CreateToDoItemCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }

        // <summary>
        /// Create to do item
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        [HttpPut("update")]
        public async Task<ActionResult> Update([FromBody]UpdateToDoItemCommand command)
        {
            await _mediator.Send(command, HttpContext.RequestAborted);
            return Ok();
        }


        /// <summary>
        /// Get to items
        /// </summary>
        /// <returns></returns>
        [HttpGet("get")]
        public async Task<IEnumerable<ToDoItemDto>> GetAsync()
        {
            return await _mediator.Send(new GetToDoItemsQuery(), HttpContext.RequestAborted);
        }
    }
}