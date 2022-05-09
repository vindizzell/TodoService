using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using TodoApi.Models;
using TodoApiDTO.Infrastructure.Options;

namespace TodoApiDTO.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen(c => c.SwaggerDoc(
                    "v1", new OpenApiInfo
                    {
                       Title = "Todo API",
                       Version = "v1"
                    }));

        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
            => services.AddDbContext<TodoContext>(options => options
                .UseSqlServer(configuration.GetOptions<SqlServerSettings>().ConnectionString));
    }
}