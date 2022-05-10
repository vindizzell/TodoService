using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoList.DataAccessLayer.EF.Contexts;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.DataAccessLayer.EF.Repositories
{
    internal sealed class TodoItemRepository : IRepository<TodoItem>
    {
        private readonly TodoContext _context;

        public TodoItemRepository(TodoContext context)
            => _context = context;

        public async Task AddAsync(TodoItem entity)
        {
            await _context.TodoItems.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(TodoItem entity)
        {
            _context.TodoItems.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TodoItem>> GetAsync()
            => await _context
            .TodoItems
            .AsNoTracking()
            .ToListAsync();

        public async Task<TodoItem> GetAsync(long id)
            => await _context
            .TodoItems
            .SingleOrDefaultAsync(ti => ti.Id == id);

        public async Task UpdateAsync(TodoItem entity)
        {
            _context.TodoItems.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}