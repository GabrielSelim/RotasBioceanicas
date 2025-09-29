using WebApp.Application.BusinessInterface;
using WebApp.Application.Converter.Implementacao;
using WebApp.Application.Converter.Implementacao.Usuario;
using WebApp.Application.Dto.UsuarioDto;
using WebApp.Domain.RepositoryInterface;

namespace WebApp.Application.Business
{
    public class UsuarioBusinessImplementacao : IUsuarioBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly ConverterAtualizarUsuario _converterAtualizar;
        private readonly ConverterCriarUsuario _converterCriar;
        private readonly ConverterUsuarioRetorno _converterRetorno; 
        public UsuarioBusinessImplementacao(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
            _converterAtualizar = new ConverterAtualizarUsuario();
            _converterCriar = new ConverterCriarUsuario();
            _converterRetorno = new ConverterUsuarioRetorno();
        }

        public async Task Criar(CriarUsuarioDbo usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentException("O usuário não pode ser nulo.");

                if (string.IsNullOrWhiteSpace(usuario.NomeCompleto))
                    throw new ArgumentException("O nome completo não pode ser vazio ou nulo.");

                if (!System.Text.RegularExpressions.Regex.IsMatch(usuario.NomeCompleto, @"^[A-Za-zÀ-ÿ\s]+$"))
                    throw new ArgumentException("O nome completo deve conter apenas letras e espaços.");

                usuario.NomeCompleto = usuario.NomeCompleto.ToUpper();

                var usuarioEntity = _converterCriar.Parse(usuario);

                if (usuarioEntity == null)
                    throw new ArgumentException("Erro ao converter o usuário.");

                await _usuarioRepository.CriarAsync(usuarioEntity);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Erro de validação: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao Criar novo Usuário.", ex);
            }
        }

        public async Task Atualizar(long id, AtualizarUsuarioDto usuario)
        {
            try
            {
                if (usuario == null)
                    throw new ArgumentException("O usuário para atualização não pode ser nulo.");

                var usuarioExistente = await _usuarioRepository.ObterPorIdAsync(id);
                if (usuarioExistente == null)
                    throw new ArgumentException("Usuário não encontrado.");

                if (!string.IsNullOrWhiteSpace(usuario.Documento))
                    usuarioExistente.Documento = usuario.Documento;

                if (!string.IsNullOrWhiteSpace(usuario.EmpresaInstituicao))
                    usuarioExistente.EmpresaInstituicao = usuario.EmpresaInstituicao;

                if (!string.IsNullOrWhiteSpace(usuario.Cargo))
                    usuarioExistente.Cargo = usuario.Cargo;

                if (!string.IsNullOrWhiteSpace(usuario.SetorAtuacao))
                    usuarioExistente.SetorAtuacao = usuario.SetorAtuacao;

                if (!string.IsNullOrWhiteSpace(usuario.WebsiteEmpresa))
                    usuarioExistente.WebsiteEmpresa = usuario.WebsiteEmpresa;

                if (usuario.ConsentiuEntrarGrupoWhatsApp.HasValue)
                    usuarioExistente.ConsentiuEntrarGrupoWhatsApp = usuario.ConsentiuEntrarGrupoWhatsApp.Value;

                if (usuario.AutorizaUsoImagem.HasValue)
                    usuarioExistente.AutorizaUsoImagem = usuario.AutorizaUsoImagem.Value;

                if (usuario.DesejaReceberComunicados.HasValue)
                    usuarioExistente.DesejaReceberComunicados = usuario.DesejaReceberComunicados.Value;

                await _usuarioRepository.AtualizarAsync(usuarioExistente);
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException($"Erro de validação: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar o Usuário.", ex);
            }
        }
    }
}