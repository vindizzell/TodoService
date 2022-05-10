using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Extensions;
using TodoList.BusinessLayer.Model;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Repositories;

namespace TodoList.BusinessLayer.Queries.Handlers
{
    internal sealed class GetTodoItemByIdHandler : IRequestHandler<GetTodoItemByIdQuery, TodoItemResponse>
    {
        private readonly IRepository<TodoItem> _repository;

        public GetTodoItemByIdHandler(IRepository<TodoItem> repository)
            => _repository = repository;

        public async Task<TodoItemResponse> Handle(GetTodoItemByIdQuery query, CancellationToken cancellationToken = default)
        {
            var todoItem = await _repository.GetAsync(query.Id);
            return todoItem == null ? null : todoItem.ToDto();
        }
    }
}