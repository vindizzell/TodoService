using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Commands;
using TodoList.BusinessLayer.Commands.Handlers;
using TodoList.BusinessLayer.Model;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.BusinessLayer.Tests.Commands
{
    public class CreateTodoItemHandlerTests : BaseTestsSetUp
    {
        [Test]
        public async Task CreateNewItem_Test()
        {
            var id = 5L;
            var command = new CreateTodoItemCommand("Test", true);
            _repository.AddAsync(Arg.Any<TodoItem>())
                .Returns(Task.FromResult).AndDoes(c => ((TodoItem)c[0]).Id = id);

            var handler = new CreateTodoItemHandler(_repository);

            var result = await handler.Handle(command);

            result.Should().BeEquivalentTo(new TodoItemResponse(id, command.Name, command.IsComplete));
            await _repository.Received(1).AddAsync(Arg.Any<TodoItem>());
        }
    }
}
