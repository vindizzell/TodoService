using Microsoft.Extensions.Configuration;

namespace TodoApiDTO.Infrastructure.Extensions
{
    public static class ConfigurationExtensions
    {
        public static TOption GetOptions<TOption>(this IConfiguration configuration)
            where TOption : class, new()
            => configuration
                .GetSection(typeof(TOption).Name)
                .Get<TOption>();
    }
}