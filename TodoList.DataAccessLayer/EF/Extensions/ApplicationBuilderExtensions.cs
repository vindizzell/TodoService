using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodoList.DataAccessLayer.EF.Contexts;

namespace TodoList.DataAccessLayer.EF.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static void ApplyMigration(this IApplicationBuilder app)
        {
            using var services = app.ApplicationServices.CreateScope();

            var dbContext = services.ServiceProvider.GetService<TodoContext>();

            dbContext.Database.Migrate();
        }
    }
}