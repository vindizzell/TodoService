using System.Collections.Generic;
using MediatR;
using TodoList.BusinessLayer.Model;

namespace TodoList.BusinessLayer.Queries
{
    public class GetAllTodoItemsQuery : IRequest<IEnumerable<TodoItemResponse>>
    {
    }
}