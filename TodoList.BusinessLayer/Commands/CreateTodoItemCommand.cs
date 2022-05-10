using MediatR;
using TodoList.BusinessLayer.Model;

namespace TodoList.BusinessLayer.Commands
{
    public class CreateTodoItemCommand : IRequest<TodoItemResponse>
    {
        public string Name { get; set; }
        public bool IsComplete { get; set; }
        
        public CreateTodoItemCommand(string name, bool isComplete)
            => (Name, IsComplete) = (name, isComplete);
    }
}
