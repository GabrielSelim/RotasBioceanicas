using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApp.Application.Dto.Banner;
using WebApp.Application.Hypermedia.Constants;

namespace WebApp.Application.Hypermedia.Enricher
{
    public class BannerEnricher : ContentResponseEnricher<BannerRetornoDbo>
    {
        protected override Task EnrichModel(BannerRetornoDbo content, IUrlHelper urlHelper)
        {
            var path = "api/Banner";
            string selfLink = GetLink(content.Id, urlHelper, path);

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = selfLink,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultGet
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.POST,
                Href = selfLink,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPost
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = selfLink,
                Rel = RelationType.self,
                Type = ResponseTypeFormat.DefaultPatch
            });
            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.DELETE,
                Href = selfLink,
                Rel = RelationType.self,
                Type = "int"
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.GET,
                Href = GetLink(content.Ordem, urlHelper, $"{path}/ordem/{content.Ordem}"),
                Rel = "porOrdem",
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = GetLink(content.Id, urlHelper, $"{path}/{content.Id}/ativar-desativar"),
                Rel = "ativarOuDesativar",
                Type = ResponseTypeFormat.DefaultPatch
            });

            return Task.CompletedTask;
        }

        private string GetLink(object id, IUrlHelper urlHelper, string path)
        {
            lock (this)
            {
                var url = new { controller = path, id };
                return new StringBuilder(urlHelper.Link("DefaultApi", url)).Replace("%2F", "/").ToString();
            }
        }
    }
}