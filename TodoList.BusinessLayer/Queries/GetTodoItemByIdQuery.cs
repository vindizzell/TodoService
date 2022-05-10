using MediatR;
using TodoList.BusinessLayer.Model;

namespace TodoList.BusinessLayer.Queries
{
    public class GetTodoItemByIdQuery : IRequest<TodoItemResponse>
    {
        public long Id { get; set; }

        public GetTodoItemByIdQuery(long id)
        {
            Id = id;
        }
    }
}
