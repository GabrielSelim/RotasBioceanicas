using WebApp.Application.Hypermedia.Enricher;
using WebApp.Application.Hypermedia.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace WebApp.Application.Extensions
{
    public static class EnricherCollectionExtensions
    {
        public static IServiceCollection AddEnrichers(this IServiceCollection services, HyperMediaFilterOptions filterOptions)
        {
            return services;
        }
    }
}