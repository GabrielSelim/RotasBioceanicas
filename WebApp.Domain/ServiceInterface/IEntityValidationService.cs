namespace WebApp.Domain.ServiceInterface
{
    public interface IEntityValidationService<T>
    {
        void Validate(T entity);
    }
}