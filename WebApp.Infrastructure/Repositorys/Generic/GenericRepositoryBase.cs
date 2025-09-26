using Microsoft.EntityFrameworkCore;
using WebApp.Domain.Entity.Base;
using WebApp.Domain.Entity.Validations;
using WebApp.Domain.Generic;
using WebApp.Domain.ServiceInterface;
using WebApp.Infrastructure.Services.Validation;
using WebApp.Model.Context;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Infrastructure.Repositorys.Generic
{
    public class GenericRepositoryBase<T> : IRepositoryBase<T> where T : BaseEntity
    {
        protected MySQLContext _context;
        private DbSet<T> dataset;
        private readonly IEntityValidationService<T> _validationService;

        public GenericRepositoryBase(MySQLContext context)
        {
            _validationService = ValidationServiceFactory.GetValidationService<T>();
            _context = context;
            dataset = _context.Set<T>();
        }

        public async Task<T> ObterPorIdAsync(long id)
        {
            return await dataset.FirstOrDefaultAsync(p => p.Id.Equals(id));
        }

        public async Task<List<T>> ObterTodosAsync()
        {
            return await dataset.ToListAsync();
        }

        public async Task<T> CriarAsync(T item)
        {
            try
            {
                if (item is IEntityValidator validator)
                {
                    validator.Validate();
                }
                else
                {
                    _validationService.Validate(item);
                }

                await dataset.AddAsync(item);
                await _context.SaveChangesAsync();

                return item;
            }
            catch (ValidationException ex)
            {
                throw new ArgumentException($"Erro de validação: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao salvar a entidade no banco de dados.", ex);
            }
        }

        public async Task<T> AtualizarAsync(T item)
        {
            if (!await ExisteAsync(item.Id))
                throw new ArgumentException("A entidade com o ID especificado não existe.");

            var result = await dataset.FirstOrDefaultAsync(p => p.Id.Equals(item.Id));

            if (result == null)
                throw new ArgumentException("A entidade com o ID especificado não foi encontrada.");

            try
            {
                _validationService.Validate(item);

                _context.Entry(result).CurrentValues.SetValues(item);

                await _context.SaveChangesAsync();

                return item;
            }
            catch (ValidationException ex)
            {
                throw new ArgumentException($"Erro de validação: {ex.Message}", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro ao atualizar a entidade no banco de dados.", ex);
            }
        }

        public async Task DeletarAsync(long id)
        {
            var result = await dataset.FirstOrDefaultAsync(p => p.Id.Equals(id));

            if (result == null)
            {
                throw new KeyNotFoundException("Entidade não encontrada para o ID especificado.");
            }

            try
            {
                dataset.Remove(result);
                await _context.SaveChangesAsync();
            }
            catch (ArgumentException ex)
            {
                throw new ArgumentException(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ExisteAsync(long id)
        {
            return await dataset.AnyAsync(p => p.Id.Equals(id));
        }

        public async Task<List<T>> ObterComPaginacaoAsync(int pageNumber, int pageSize, string sortDirection)
        {
            var query = dataset.AsQueryable();

            if (sortDirection == "asc")
            {
                query = query.OrderBy(e => e.Id);
            }
            else if (sortDirection == "desc")
            {
                query = query.OrderByDescending(e => e.Id);
            }

            return await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetCountAsync()
        {
            return await dataset.CountAsync();
        }
    }
}