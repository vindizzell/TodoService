using FluentAssertions;
using NSubstitute;
using NUnit.Framework;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Commands;
using TodoList.BusinessLayer.Commands.Handlers;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.BusinessLayer.Tests.Commands
{
    public class DeleteTodoItemHandlerTests : BaseTestsSetUp
    {
        [Test]
        public async Task DeleteExistItem_Test()
        {
            var command = new DeleteTodoItemCommand(1L);
            _repository.GetAsync(Arg.Is(command.Id)).Returns(DefaultTodoItem);
            var handler = new DeleteTodoItemHandler(_repository);

            await handler.Handle(command);

            await _repository.Received(1)
                .DeleteAsync(Arg.Is<TodoItem>(c => c.Id == DefaultTodoItem.Id 
                && c.IsComplete == DefaultTodoItem.IsComplete
                && c.Name == DefaultTodoItem.Name));
            command.Success.Should().BeTrue();
            await _repository.Received(1).GetAsync(Arg.Is(command.Id));
        }

        [Test]
        public async Task DeleteNotExistItem_Test()
        {
            var command = new DeleteTodoItemCommand(5L);
            _repository.GetAsync(Arg.Is(command.Id)).Returns((TodoItem)null);
            var handler = new DeleteTodoItemHandler(_repository);

            await handler.Handle(command);

            await _repository.Received(1).GetAsync(Arg.Is(command.Id));
            command.Success.Should().BeFalse();
            await _repository.DidNotReceive().DeleteAsync(Arg.Any<TodoItem>());
        }
    }
}
