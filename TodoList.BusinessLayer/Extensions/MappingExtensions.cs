using TodoList.BusinessLayer.Model;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.BusinessLayer
{
    public static class MappingExtensions
    {
        public static TodoItemResponse ToDto(this TodoItem todoItem)
            => new TodoItemResponse
            {
                Id = todoItem.Id,
                IsComplete = todoItem.IsComplete,
                Name = todoItem.Name
            };
    }
}