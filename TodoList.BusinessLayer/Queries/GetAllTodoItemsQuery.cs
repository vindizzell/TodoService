using System.Collections.Generic;
using MediatR;
using TodoList.BusinessLayer.Model;

namespace TodoList.BusinessLayer.Queries
{
    public sealed class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItemResponse>>
    {
    }
}