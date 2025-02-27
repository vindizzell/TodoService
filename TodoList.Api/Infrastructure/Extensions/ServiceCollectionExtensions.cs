using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace TodoList.Api.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddSwagger(this IServiceCollection services)
            => services
                .AddSwaggerGen(c =>
                {
                    c.SwaggerDoc(
                        "v1", new OpenApiInfo
                        {
                            Title = "Todo API",
                            Version = "v1"
                        });
                    
                    foreach (var fileName in Directory.GetFiles(AppContext.BaseDirectory, "*.xml"))
                    {
                        c.IncludeXmlComments(fileName, true);
                    }
                });
    }
}