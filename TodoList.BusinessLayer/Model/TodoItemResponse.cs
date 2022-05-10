namespace TodoList.BusinessLayer.Model
{
    public class TodoItemResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool IsComplete { get; set; }

        public TodoItemResponse(long id, string name, bool isComplete)
            => (Id, Name, IsComplete) = (id, name, isComplete);
    }
}