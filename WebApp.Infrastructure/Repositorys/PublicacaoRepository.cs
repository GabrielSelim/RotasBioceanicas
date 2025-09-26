using System.Data.Entity;
using WebApp.Domain.Entity;
using WebApp.Domain.RepositoryInterface;
using WebApp.Infrastructure.Repositorys.Generic;
using WebApp.Model.Context;

namespace WebApp.Infrastructure.Repositorys
{
    public class PublicacaoRepository : GenericRepositoryBase<Publicacao>, IPublicacaoRepository
    {
        private readonly MySQLContext _context;
        public PublicacaoRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Publicacao>> ListarPublicadasAsync()
        {
            return await _context.Publicacaoes
                .Where(p => p.Publicado)
                .OrderByDescending(p => p.DataPublicacao)
                .ToListAsync();
        }

        public async Task<List<Publicacao>> ListarPorAutorAsync(int autorId)
        {
            return await _context.Publicacaoes
                .Where(p => p.AutorId == autorId)
                .OrderByDescending(p => p.DataPublicacao)
                .ToListAsync();
        }

        public async Task<Publicacao?> ObterPorTituloAsync(string titulo)
        {
            return await _context.Publicacaoes.FirstOrDefaultAsync(p => p.Titulo == titulo);
        }

        public async Task<bool> AlterarStatusPublicacaoAsync(long id, bool publicado)
        {
            var publicacao = await _context.Publicacaoes.FirstOrDefaultAsync(p => p.Id == id);
            if (publicacao == null) return false;
            publicacao.Publicado = publicado;
            await _context.SaveChangesAsync();
            return true;
        }
    }
}