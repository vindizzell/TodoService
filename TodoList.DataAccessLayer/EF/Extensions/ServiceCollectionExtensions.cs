using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TodoList.DataAccessLayer.EF.Contexts;
using TodoList.DataAccessLayer.EF.Model;
using TodoList.DataAccessLayer.EF.Options;
using TodoList.DataAccessLayer.EF.Repositories;

namespace TodoList.DataAccessLayer.EF.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<TodoContext>(options => options
                .UseSqlServer(configuration.GetOptions<SqlServerSettings>().ConnectionString));

        public static IServiceCollection AddDataAccessLayerServices(this IServiceCollection services)
            => services
                .AddScoped<IRepository<TodoItem>, TodoItemRepository>();
    }
}