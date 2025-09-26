using WebApp.Domain.Entity;
using WebApp.Domain.ServiceInterface;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Infrastructure.Services.Validation
{
    public class UsuarioValidationService : IEntityValidationService<Usuario>
    {
        public void Validate(Usuario usuario)
        {
            if (string.IsNullOrWhiteSpace(usuario.NomeCompleto))
                throw new ValidationException("O campo 'Nome Completo' é obrigatório.");

            if (usuario.NomeCompleto.Length < 3 || usuario.NomeCompleto.Length > 200)
                throw new ValidationException("O campo 'Nome Completo' deve ter entre 3 e 200 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.Email))
                throw new ValidationException("O campo 'E-mail' é obrigatório.");

            if (usuario.Email.Length > 150)
                throw new ValidationException("O campo 'E-mail' deve ter no máximo 150 caracteres.");

            if (!new EmailAddressAttribute().IsValid(usuario.Email))
                throw new ValidationException("Formato de e-mail inválido.");

            if (!string.IsNullOrWhiteSpace(usuario.Documento) && usuario.Documento.Length > 20)
                throw new ValidationException("O campo 'Documento' deve ter no máximo 20 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.Pais))
                throw new ValidationException("O campo 'País' é obrigatório.");

            if (usuario.Pais.Length > 100)
                throw new ValidationException("O campo 'País' deve ter no máximo 100 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.Cidade))
                throw new ValidationException("O campo 'Cidade' é obrigatório.");

            if (usuario.Cidade.Length > 150)
                throw new ValidationException("O campo 'Cidade' deve ter no máximo 150 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.Estado))
                throw new ValidationException("O campo 'Estado' é obrigatório.");

            if (usuario.Estado.Length > 150)
                throw new ValidationException("O campo 'Estado' deve ter no máximo 150 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.DDI))
                throw new ValidationException("O campo 'DDI' é obrigatório.");
            if (usuario.DDI.Length > 5)
                throw new ValidationException("O campo 'DDI' deve ter no máximo 5 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.TelefoneNumero))
                throw new ValidationException("O campo 'Número de Telefone' é obrigatório.");

            if (usuario.TelefoneNumero.Length > 20)
                throw new ValidationException("O campo 'Número de Telefone' deve ter no máximo 20 caracteres.");

            if (!string.IsNullOrWhiteSpace(usuario.EmpresaInstituicao) && usuario.EmpresaInstituicao.Length > 150)
                throw new ValidationException("O campo 'Empresa/Instituição' deve ter no máximo 150 caracteres.");

            if (!string.IsNullOrWhiteSpace(usuario.Cargo) && usuario.Cargo.Length > 100)
                throw new ValidationException("O campo 'Cargo' deve ter no máximo 100 caracteres.");

            if (!string.IsNullOrWhiteSpace(usuario.SetorAtuacao) && usuario.SetorAtuacao.Length > 100)
                throw new ValidationException("O campo 'Setor de Atuação' deve ter no máximo 100 caracteres.");

            if (!string.IsNullOrWhiteSpace(usuario.WebsiteEmpresa) && usuario.WebsiteEmpresa.Length > 200)
                throw new ValidationException("O campo 'Website da Empresa' deve ter no máximo 200 caracteres.");

            if (string.IsNullOrWhiteSpace(usuario.SenhaHash))
                throw new ValidationException("O campo 'SenhaHash' é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                throw new ValidationException("O campo 'Senha' é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Role))
                throw new ValidationException("O campo 'Role' é obrigatório.");

            if (usuario.Role.Length > 30)
                throw new ValidationException("O campo 'Role' deve ter no máximo 30 caracteres.");

            if (usuario.TermosAceitosEm == default)
                throw new ValidationException("O campo 'TermosAceitosEm' é obrigatório.");
        }
    }
}