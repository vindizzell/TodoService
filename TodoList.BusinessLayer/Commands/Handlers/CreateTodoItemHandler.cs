﻿using MediatR;
using System.Threading;
using System.Threading.Tasks;
using TodoList.BusinessLayer.Model;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Repositories;

namespace TodoList.BusinessLayer.Commands.Handlers
{
    public class CreateTodoItemHandler : IRequestHandler<CreateTodoItemCommand, TodoItemResponse>
    {
        private readonly IRepository<TodoItem> _repository;

        public CreateTodoItemHandler(IRepository<TodoItem> repository)
            => _repository = repository;

        public async Task<TodoItemResponse> Handle(CreateTodoItemCommand command, CancellationToken cancellationToken)
        {
            var todoItem = new TodoItem
            {
                Name = command.Name,
                IsComplete = command.IsComplete
            };

            await _repository.AddAsync(todoItem);
            
            return todoItem.ToDto();
        }
    }
}
