using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Commands;
using TodoList.BusinessLayer.Model;
using TodoList.BusinessLayer.Queries;

namespace TodoList.Api.Controllers
{
    /// <summary>
    /// Контроллер для работы с задачами
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="mediator"></param>
        public TodoItemsController(IMediator mediator)
            => _mediator = mediator;

        /// <summary>
        /// Получение списка задач
        /// </summary>
        /// <response code="200">Список задач</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItemResponse>>> GetTodoItems()
        {
            var query = new GetAllTodoItemsQuery();
            var todoItems = await _mediator.Send(query);
            return Ok(todoItems);
        }

        /// <summary>
        /// Получение задачи по идентификатору
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <response code="200">Задача</response>
        /// <response code="404">Задача не найдена</response>
        [HttpGet("{id:long}")]
        public async Task<ActionResult<TodoItemResponse>> GetTodoItem(long id)
        {
            var query = new GetTodoItemByIdQuery(id);
            var todoItem = await _mediator.Send(query);
            return todoItem == null ? (ActionResult<TodoItemResponse>)NotFound() : Ok(todoItem);
        }

        /// <summary>
        /// Обновление задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <param name="updateTodoItemRequest">Данные для обновления</param>
        /// <response code="204">Задача обновлена</response>
        /// <response code="400">Некорректные данные</response>
        /// <response code="404">Задача не найдена</response>
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

        /// <summary>
        /// Добавление новой задачи
        /// </summary>
        /// <param name="createTodoItemRequest">Данные задачи</param>
        /// <returns>Добавленныя задача</returns>
        /// <response code="201">Задача создана</response>
        /// <response code="400">Некорректные данные</response>
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

        /// <summary>
        /// Удаление задачи
        /// </summary>
        /// <param name="id">Идентификатор задачи</param>
        /// <response code="204">Задача удалена</response>
        /// <response code="404">Задача не найдена</response>
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