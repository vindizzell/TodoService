using MediatR;

namespace TodoList.BusinessLayer.Commands
{
    public sealed class UpdateTodoItemCommand : IRequest<Unit>
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public bool Success { get; set; }
        public UpdateTodoItemCommand(long id, string name, bool isComplete)
            => (Id, Name, IsComplete, Success) = (id, name, isComplete, true);
    }
}