using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Repositories;

namespace TodoList.BusinessLayer.Commands.Handlers
{
    public class DeleteTodoItemHandler : IRequestHandler<DeleteTodoItemCommand>
    {
        private readonly IRepository<TodoItem> _repository;

        public DeleteTodoItemHandler(IRepository<TodoItem> repository)
            => _repository = repository;

        public async Task<Unit> Handle(DeleteTodoItemCommand command, CancellationToken cancellationToken = default)
        {
            var todoItem = await _repository.GetAsync(command.Id);

            if (todoItem == null)
            {
                command.Success = false;
                return Unit.Value;
            }

            await _repository.DeleteAsync(todoItem);

            return Unit.Value;
        }
    }
}
