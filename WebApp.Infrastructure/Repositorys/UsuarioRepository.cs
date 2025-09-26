using WebApp.Domain.Entity;
using WebApp.Domain.RepositoryInterface;
using WebApp.Model.Context;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using WebApp.Infrastructure.Repositorys.Generic;
using WebApp.Domain.Entity.Validations;
using WebApp.Infrastructure.Services.Validation;

namespace WebApp.Infrastructure.Repositorys
{
    public class UsuarioRepository : GenericRepositoryBase<Usuario>, IUsuarioRepository
    {
        private readonly MySQLContext _context;

        public UsuarioRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public Usuario ValidacaoCredencial(string email, string senha)
        {
            var senhaHash = ComputeHash(senha, SHA256.Create());
            return _context.Usuarios.FirstOrDefault(u => u.Email == email && u.SenhaHash == senhaHash);
        }

        public Usuario ObterPorEmail(string email)
        {
            return _context.Usuarios.FirstOrDefault(u => u.Email == email);
        }

        public bool RevokeToken(string email)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario is null) return false;
            usuario.RefreshToken = null;
            _context.SaveChanges();
            return true;
        }

        private string ComputeHash(string input, HashAlgorithm hashAlgorithm)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashedBytes = hashAlgorithm.ComputeHash(inputBytes);

            var builder = new StringBuilder();
            foreach (var t in hashedBytes)
            {
                builder.Append(t.ToString("x2"));
            }

            return builder.ToString();
        }

        public bool Existe(long id)
        {
            return _context.Usuarios.Any(p => p.Id.Equals(id));
        }

        public override async Task<Usuario> CriarAsync(Usuario usuario)
        {
            if (_context.Usuarios.Any(u => u.Email == usuario.Email))
                throw new ValidationException("Já existe um usuário cadastrado com este e-mail.");

            usuario.SenhaHash = ComputeHash(usuario.Senha, SHA256.Create());

            if (usuario is IEntityValidator validator)
                validator.Validate();
            else
                ValidationServiceFactory.GetValidationService<Usuario>().Validate(usuario);

            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();

            return usuario;
        }
    }
}
