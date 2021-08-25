using Microsoft.EntityFrameworkCore;
using SmartSchool.API.Common.Interfaces;
using SmartSchool.API.Data;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SmartSchool.API.Repositories
{
    public class StudentRepository : BaseRepository<Student>, IStudentRepository
    {
        private readonly SmartContext _context;

        public StudentRepository(SmartContext context) : base(context)
        {
            _context = context;
        }
        public async Task<RestListResponse<Student>> GetAllStudents(PageParams parameters) 
        {
            IQueryable<Student> query = _context.Students;

            query = query.AsNoTracking().OrderBy(s => s.Id);

            if (!string.IsNullOrEmpty(parameters.Name))
                query = query.Where(aluno => aluno.Name
                                                  .ToUpper()
                                                  .Contains(parameters.Name.ToUpper()) ||
                                             aluno.LastName
                                                  .ToUpper()
                                                  .Contains(parameters.Name.ToUpper()));

            if (parameters.Registration > 0)
                query = query.Where(aluno => aluno.Registration == parameters.Registration);

            if (parameters.Active != null)
                query = query.Where(aluno => aluno.Active == parameters.Active);


            return await RestListResponse<Student>.CreateAsync(query, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<IList<Student>> GetAllStudentsWithSubject()
        {
            IQueryable<Student> query = _context.Students;

            query = query.Include(s => s.StudentsSubjects)
                         .ThenInclude(sub => sub.Subject)
                         .ThenInclude(t => t.Teacher)
                         .AsNoTracking()
                         .OrderBy(s => s.Id);

            return await query.ToArrayAsync();
        }

        public async Task<IList<Student>> GetAllStudentBySubjectId(int id)
        {
            IQueryable<Student> query = _context.Students;

            query = query.Include(s => s.StudentsSubjects)
                         .AsNoTracking()
                         .OrderBy(s => s.Id)
                         .Where(student => student.StudentsSubjects.Any(ss => ss.SubjectId == id));

            return await query.ToArrayAsync();
        }

        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.FirstOrDefaultAsync(student => student.Id == id);
        }

        public async Task<Student> GetStudentByName(string name, string lastName)
        {
            return await _context.Students.FirstOrDefaultAsync(s => 
                s.Name.Contains(name) && s.LastName.Contains(lastName)
            );
        }

    }
}
