using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using MediatR;
using TodoList.BusinessLayer.Extensions;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Repositories;
using TodoList.BusinessLayer.Model;

namespace TodoList.BusinessLayer.Queries.Handlers
{
    internal sealed class GetAllTodoItemsHandler : IRequestHandler<GetAllTodoItemsQuery, IEnumerable<TodoItemResponse>>
    {
        private readonly IRepository<TodoItem> _repository;

        public GetAllTodoItemsHandler(IRepository<TodoItem> repository)
            => _repository = repository;

        public async Task<IEnumerable<TodoItemResponse>> Handle(GetAllTodoItemsQuery query, CancellationToken cancellationToken = default)
            => (await _repository.GetAsync()).Select(ti => ti.ToDto());
    }
}