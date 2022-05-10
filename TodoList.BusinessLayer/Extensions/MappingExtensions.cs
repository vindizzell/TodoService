using TodoList.BusinessLayer.Model;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.BusinessLayer
{
    public static class MappingExtensions
    {
        public static TodoItemResponse ToDto(this TodoItem todoItem)
            => new TodoItemResponse(todoItem.Id, todoItem.Name, todoItem.IsComplete);
    }
}