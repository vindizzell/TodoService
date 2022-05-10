using TodoList.DataAccessLayer.EF.Model.Base;

namespace TodoList.DataAccessLayer.EF.Model
{
    public class TodoItem : IEntity
    {
        public long Id { get; set; }

        public string Name { get; set; }
        
        public bool IsComplete { get; set; }

        public string Secret { get; set; }
    }
}