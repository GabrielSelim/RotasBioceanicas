using WebApp.Application.Hypermedia.Filters;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Application.Hypermedia.Enricher;

namespace WebApp.Application.Extensions
{
    public static class EnricherCollectionExtensions
    {
        public static IServiceCollection AddEnrichers(this IServiceCollection services, HyperMediaFilterOptions filterOptions)
        {
            filterOptions.ContentResponseEnricherList.Add(new BannerEnricher());
            filterOptions.ContentResponseEnricherList.Add(new PublicacaoEnricher());

            return services;
        }
    }
}