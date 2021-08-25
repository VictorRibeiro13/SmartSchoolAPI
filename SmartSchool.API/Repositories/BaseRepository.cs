
using SmartSchool.API.Data;

namespace SmartSchool.API.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly SmartContext _context;

        public BaseRepository(SmartContext context)
        {
            _context = context;
        }

        public async void Add<Entity>(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async void Delete<Entity>(T entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async void Update<Entity>(T entity)
        {
            _context.Update(entity);
           await _context.SaveChangesAsync();
        }
    }
}
