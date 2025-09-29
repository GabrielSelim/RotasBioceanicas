using Microsoft.AspNetCore.Mvc;
using System.Text;
using WebApp.Application.Dto.Publicacao;
using WebApp.Application.Hypermedia.Constants;

namespace WebApp.Application.Hypermedia.Enricher
{
    public class PublicacaoEnricher : ContentResponseEnricher<PublicacaoRetornoDbo>
    {
        protected override Task EnrichModel(PublicacaoRetornoDbo content, IUrlHelper urlHelper)
        {
            var path = "api/Publicacao";
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
                Href = GetLink(content.AutorId, urlHelper, $"{path}/autor/{content.AutorId}"),
                Rel = "porAutor",
                Type = ResponseTypeFormat.DefaultGet
            });

            content.Links.Add(new HyperMediaLink()
            {
                Action = HttpActionVerb.PATCH,
                Href = GetLink(content.Id, urlHelper, $"{path}/{content.Id}/alterar-status"),
                Rel = "alterarStatusPublicacao",
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