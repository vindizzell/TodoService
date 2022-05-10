using Microsoft.EntityFrameworkCore;
using TodoList.DataAccessLayer.EF.Configuration;
using TodoList.DataAccessLayer.EF.Model;

namespace TodoList.DataAccessLayer.EF.Contexts
{
    internal class TodoContext : DbContext
    {
        public DbSet<TodoItem> TodoItems { get; set; }

        public TodoContext(DbContextOptions<TodoContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .ApplyConfiguration(new TodoItemConfiguration());
        }
    }
}