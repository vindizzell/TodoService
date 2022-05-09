using Microsoft.EntityFrameworkCore;
using TodoApiDTO.Models;
using TodoApiDTO.Models.Configuration;

namespace TodoApi.Models
{
    public class TodoContext : DbContext
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