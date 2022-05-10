namespace TodoList.BusinessLayer.Model
{
    public class UpdateTodoItemRequest
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }
    }
}