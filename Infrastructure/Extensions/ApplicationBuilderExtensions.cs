using Microsoft.AspNetCore.Builder;

namespace TodoApiDTO.Infrastructure.Extensions
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSwaggerUI(this IApplicationBuilder app)
            => app
                .UseSwagger()
                .UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Todo API V1");
                    c.RoutePrefix = string.Empty;
                });
    }
}