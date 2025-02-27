﻿using MediatR;

namespace TodoList.BusinessLayer.Commands
{
    public sealed class DeleteTodoItemCommand : IRequest
    {
        public long Id { get; set; }

        public bool Success { get; set; }
        
        public DeleteTodoItemCommand(long id)
            => (Id, Success) = (id, true);
    }
}