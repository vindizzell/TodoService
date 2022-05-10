using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Repositories;

namespace TodoList.BusinessLayer.Commands.Handlers
{
    internal sealed class UpdateTodoItemHandler : IRequestHandler<UpdateTodoItemCommand>
    {
        private readonly IRepository<TodoItem> _repository;

        public UpdateTodoItemHandler(IRepository<TodoItem> repository)
            => _repository = repository;
        
        public async Task<Unit> Handle(UpdateTodoItemCommand command, CancellationToken cancellationToken = default)
        {
            var todoItem = await _repository.GetAsync(command.Id);
            
            if(todoItem == null)
            {
                command.Success = false;
                return Unit.Value;
            }
            
            todoItem.Name = command.Name;
            todoItem.IsComplete = command.IsComplete;
            
            try
            {
                await _repository.UpdateAsync(todoItem);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!(await _repository.GetAsync()).Any(t => t.Id == command.Id))
                    command.Success = false;
            }
            
            return Unit.Value;
        }
    }
}