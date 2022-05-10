namespace TodoList.BusinessLayer.Model
{
    /// <summary>
    /// Запрос обновления деталей задачи
    /// </summary>
    public class UpdateTodoItemRequest
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
    }
}