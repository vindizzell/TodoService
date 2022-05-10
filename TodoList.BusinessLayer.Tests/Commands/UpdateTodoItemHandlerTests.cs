using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using NSubstitute;
using NUnit.Framework;
using System.Linq;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Commands;
using TodoList.BusinessLayer.Commands.Handlers;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.BusinessLayer.Tests.Commands
{
    public class UpdateTodoItemHandlerTests : BaseTestsSetUp
    {
        [Test]
        public async Task Update_NotExistItem_Test()
        {
            var command = new UpdateTodoItemCommand(5L, "Test", true);
            _repository.GetAsync(Arg.Is(command.Id)).Returns((TodoItem)null);
            var handler = new UpdateTodoItemHandler(_repository);

            await handler.Handle(command);

            command.Success.Should().BeFalse();
            await _repository.Received(1).GetAsync(Arg.Is(command.Id));
            await _repository.DidNotReceive().UpdateAsync(Arg.Any<TodoItem>());
        }

        [Test]
        public async Task Update_ExistItem_Test()
        {
            var command = new UpdateTodoItemCommand(DefaultTodoItem.Id, "Test 123", true);
            _repository.GetAsync(Arg.Is(command.Id)).Returns(DefaultTodoItem);
            var handler = new UpdateTodoItemHandler(_repository);

            await handler.Handle(command);

            command.Success.Should().BeTrue();
            await _repository.Received(1).GetAsync(Arg.Is(command.Id));
            await _repository.Received(1).UpdateAsync(Arg.Is<TodoItem>(x => x.Id == command.Id
                && x.Name == command.Name
                && x.IsComplete == command.IsComplete));
        }

        [Test]
        public async Task Update_Exception_NotUpdate_Test()
        {
            var command = new UpdateTodoItemCommand(DefaultTodoItem.Id, "Test 123", true);
            _repository.GetAsync(Arg.Is(command.Id)).Returns(DefaultTodoItem);
            _repository.GetAsync().Returns(Enumerable.Empty<TodoItem>());
            _repository.When(x => x.UpdateAsync(Arg.Any<TodoItem>()))
                .Do(x => { throw new DbUpdateConcurrencyException(); });
            var handler = new UpdateTodoItemHandler(_repository);

            await handler.Handle(command);

            command.Success.Should().BeFalse();
            await _repository.Received(1).GetAsync(Arg.Is(command.Id));
            await _repository.Received(1).UpdateAsync(Arg.Is<TodoItem>(x => x.Id == command.Id
                && x.Name == command.Name
                && x.IsComplete == command.IsComplete));
            await _repository.Received(1).GetAsync();
        }

        [Test]
        public async Task Update_Exception_ButUpdate_Test()
        {
            var command = new UpdateTodoItemCommand(DefaultTodoItem.Id, "Test 123", true);
            _repository.GetAsync(Arg.Is(command.Id)).Returns(DefaultTodoItem);
            _repository.GetAsync().Returns(new[] { DefaultTodoItem });
            _repository.When(x => x.UpdateAsync(Arg.Any<TodoItem>()))
                .Do(x => { throw new DbUpdateConcurrencyException(); });
            var handler = new UpdateTodoItemHandler(_repository);

            await handler.Handle(command);

            command.Success.Should().BeTrue();
            await _repository.Received(1).GetAsync(Arg.Is(command.Id));
            await _repository.Received(1).UpdateAsync(Arg.Is<TodoItem>(x => x.Id == command.Id
                && x.Name == command.Name
                && x.IsComplete == command.IsComplete));
            await _repository.Received(1).GetAsync();
        }
    }
}
