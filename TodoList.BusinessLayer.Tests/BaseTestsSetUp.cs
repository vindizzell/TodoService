using NSubstitute;
using NUnit.Framework;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Repositories;

namespace TodoList.BusinessLayer.Tests
{
    [TestFixture]
    public abstract class BaseTestsSetUp
    {
        protected IRepository<TodoItem> _repository;
        
        [SetUp]
        public void SetUp()
        {
            _repository = Substitute.For<IRepository<TodoItem>>();
        }

        protected static TodoItem DefaultTodoItem
            => new TodoItem()
            {
                Id = 1L,
                Name = "Test",
                IsComplete = false
            };
    }
}
