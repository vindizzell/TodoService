namespace TodoList.BusinessLayer.Model
{
    /// <summary>
    /// Запрос на создание новой задачи
    /// </summary>
    public class CreateTodoItemRequest
    {
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