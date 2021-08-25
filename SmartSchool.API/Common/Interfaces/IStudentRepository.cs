using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using SmartSchool.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.API.Common.Interfaces
{
    public interface IStudentRepository: IBaseRepository<Student>
    {
        Task<RestListResponse<Student>> GetAllStudents(PageParams parameters);
        Task<Student> GetStudentById(int id);
        Task<Student> GetStudentByName(string name, string lastName);
        Task<IList<Student>> GetAllStudentsWithSubject();
        Task<IList<Student>> GetAllStudentBySubjectId(int id);
    }
}
