using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.API.Repositories
{
    public interface ITeacherRepository : IBaseRepository<Teacher>
    {
        Teacher GetTeacherById(int id);
        Task<RestListResponse<Teacher>> GetAllTeachers(PageParams parameters);
    }
}
