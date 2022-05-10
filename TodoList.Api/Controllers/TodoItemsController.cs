using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Commands;
using TodoList.BusinessLayer.Model;
using TodoList.BusinessLayer.Queries;

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public TodoItemsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemResponse>>> GetTodoItems()
        {
            var query = new GetAllTodoItemsQuery();
            var todoItems = await _mediator.Send(query);
            return Ok(todoItems);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<TodoItemResponse>> GetTodoItem(long id)
        {
            var query = new GetTodoItemByIdQuery(id);
            var todoItem = await _mediator.Send(query);
            return todoItem == null ? (ActionResult<TodoItemResponse>)NotFound() : Ok(todoItem);
        }

        [HttpPut("{id:long}")]
        public async Task<IActionResult> UpdateTodoItem(long id, UpdateTodoItemRequest updateTodoItemRequest)
        {
            if (id != updateTodoItemRequest.Id)
            {
                return BadRequest();
            }

            var command = new UpdateTodoItemCommand(updateTodoItemRequest.Id, 
                updateTodoItemRequest.Name, 
                updateTodoItemRequest.IsComplete);

            await _mediator.Send(command);
            
            if (!command.Success)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<TodoItemResponse>> CreateTodoItem(CreateTodoItemRequest createTodoItemRequest)
        {
            var command = new CreateTodoItemCommand(createTodoItemRequest.Name, 
                createTodoItemRequest.IsComplete);

            var todoItem = await _mediator.Send(command);

            return CreatedAtAction(
                nameof(GetTodoItem),
                new { id = todoItem.Id },
                todoItem);
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteTodoItem(long id)
        {
            var command = new DeleteTodoItemCommand(id);
            
            await _mediator.Send(command);
            
            if (!command.Success)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}