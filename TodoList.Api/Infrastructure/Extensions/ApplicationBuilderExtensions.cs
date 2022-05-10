using Microsoft.AspNetCore.Builder;

namespace TodoList.Api.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUi(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
                    c.RoutePrefix = string.Empty;
                });
    }
}