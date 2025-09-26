using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using WebApp.Domain.Entity;
using WebApp.Domain.Entity.Validations;
using WebApp.Domain.RepositoryInterface;
using WebApp.Infrastructure.Services.Validation;
using WebApp.Model.Context;
using WebApp.Repository.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace WebApp.Infrastructure.Repositorys
{
    public class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        private readonly MySQLContext _context;

        public UsuarioRepository(MySQLContext context) : base(context)
        {
            _context = context;
        }

        public Usuario ValidacaoCredencial(Usuario usuario)
        {
            var senha = ComputeHash(usuario.Senha, SHA256.Create());

            return _context.Usuarios.FirstOrDefault(u => (u.NomeUsuario == usuario.NomeUsuario) && (u.Senha == senha));
        }

        public Usuario ValidacaoCredencial(string usuarioNome)
        {
            return _context.Usuarios.FirstOrDefault(u => (u.NomeUsuario == usuarioNome));
        }

        public bool RevokeToken(string usuarioNome)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => (u.NomeUsuario == usuarioNome));
            if (usuario is null) return false;
            usuario.RefreshToken = null;
            _context.SaveChanges();

            return true;
        }

        public Usuario AtualizarInfoUsuario(Usuario usuario)
        {
            if (!Existe(usuario.Id)) return null;
            {
                var result = _context.Usuarios.FirstOrDefault(p => p.Id.Equals(usuario.Id));

                if (result != null)
                {
                    try
                    {
                        _context.Entry(result).CurrentValues.SetValues(usuario);
                        _context.SaveChanges();
                        return usuario;
                    }
                    catch (Exception ex)
                    {
                        throw;
                    }
                }

                return result;
            }
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

        public override Usuario Criar(Usuario usuario)
        {
            try
            {
                if (_context.Usuarios.Any(u => u.NomeUsuario == usuario.NomeUsuario))
                {
                    throw new ValidationException("Já existe um usuário cadastrado com este NomeUsuario.");
                }

                usuario.Senha = ComputeHash(usuario.Senha, SHA256.Create());

                if (usuario is IEntityValidator validator)
                {
                    validator.Validate();
                }
                else
                {
                    var validationService = ValidationServiceFactory.GetValidationService<Usuario>();
                    validationService.Validate(usuario);
                }

                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return usuario;
            }
            catch (ValidationException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar o usuário no banco de dados.", ex);
            }
        }
    }
}