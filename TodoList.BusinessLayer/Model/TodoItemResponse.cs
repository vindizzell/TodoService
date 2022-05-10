namespace TodoList.BusinessLayer.Model
{
    /// <summary>
    /// Результат запроса задачи
    /// </summary>
    public class TodoItemResponse
    {
        /// <summary>
        /// Идентифиактор задачи
        /// </summary>
        public long Id { get; set; }
        /// <summary>
        /// Наименование задачи
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Состояние завершенности задачи
        /// </summary>
        public bool IsComplete { get; set; }

        public TodoItemResponse(long id, string name, bool isComplete)
            => (Id, Name, IsComplete) = (id, name, isComplete);
    }
}