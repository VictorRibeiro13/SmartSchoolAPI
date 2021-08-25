
namespace SmartSchool.API.Repositories
{
    public interface IBaseRepository<T> where T : class
    {
        void Add<Entity>(T entity);
        void Update<Entity>(T entity);
        void Delete<Entity>(T entity);
    }
}
