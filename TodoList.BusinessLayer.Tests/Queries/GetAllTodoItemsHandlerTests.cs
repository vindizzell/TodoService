using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Model;
using TodoList.BusinessLayer.Queries;
using TodoList.BusinessLayer.Queries.Handlers;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Repositories;

namespace TodoList.BusinessLayer.Tests.Queries
{
    public class GetAllTodoItemsHandlerTests : BaseTestsSetUp
    {
        [Test]
        public async Task Return_EmptyCollection_Test()
        {
            _repository.GetAsync().Returns(Enumerable.Empty<TodoItem>());
            var handler = new GetAllTodoItemsHandler(_repository);
            var result = await handler.Handle(new GetAllTodoItemsQuery());
            
            result.Should().BeEmpty();
        }

        [Test]
        public async Task Return_NotEmptyCollection_Test()
        {
            _repository.GetAsync().Returns(new[] { DefaultTodoItem });
            var handler = new GetAllTodoItemsHandler(_repository);

            var result = await handler.Handle(new GetAllTodoItemsQuery());

            result.Should().BeEquivalentTo(new[] { new TodoItemResponse(DefaultTodoItem.Id, DefaultTodoItem.Name, DefaultTodoItem.IsComplete) });
        }
    }
}
