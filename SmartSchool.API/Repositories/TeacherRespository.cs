using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Data;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Repositories
{
    public class TeacherRepository : BaseRepository<Teacher>, ITeacherRepository
    {
        private readonly SmartContext _context;

        public TeacherRepository(SmartContext context) : base(context)
        {
            _context = context;
        }

        public Teacher GetTeacherById(int id)
        {
            return _context.Teachers.FirstOrDefault(teacher => teacher.Id == id);
        }


        public Teacher GetTeacherByRegistration(int registration)
        {
            return _context.Teachers.FirstOrDefault(teacher => teacher.Registration == registration);
        }

        public async Task<RestListResponse<Teacher>> GetAllTeachers(PageParams parameters)
        {
            IQueryable<Teacher> query = _context.Teachers;
            query = query.AsNoTracking().OrderBy(s => s.Id);
            return await RestListResponse<Teacher>.CreateAsync(query, parameters.PageNumber, parameters.PageSize);
        }
    }
}
