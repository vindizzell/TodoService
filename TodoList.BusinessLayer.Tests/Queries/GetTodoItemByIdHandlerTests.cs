using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Threading;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Model;
using TodoList.BusinessLayer.Queries;
using TodoList.BusinessLayer.Queries.Handlers;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.BusinessLayer.Tests.Queries
{
    public class GetTodoItemByIdHandlerTests : BaseTestsSetUp
    {
        [Test]
        public async Task Request_ExistItem_Test()
        {
            _repository.GetAsync(Arg.Is(DefaultTodoItem.Id)).Returns(DefaultTodoItem);
            var handler = new GetTodoItemByIdHandler(_repository);
            var query = new GetTodoItemByIdQuery(DefaultTodoItem.Id);

            var result = await handler.Handle(query, CancellationToken.None);

            result.Should().BeEquivalentTo(new TodoItemResponse(DefaultTodoItem.Id, DefaultTodoItem.Name, DefaultTodoItem.IsComplete));
        }

        [Test]
        public async Task Request_NotExistItem_Test()
        {
            var query = new GetTodoItemByIdQuery(5L);
            _repository.GetAsync(Arg.Is(query.Id)).Returns((TodoItem)null);
            var handler = new GetTodoItemByIdHandler(_repository);

            var result = await handler.Handle(query);

            result.Should().BeNull();
        }
    }
}
