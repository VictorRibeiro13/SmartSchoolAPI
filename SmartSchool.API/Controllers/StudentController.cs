using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.Common.Interfaces;
using SmartSchool.API.DTOs;
using SmartSchool.API.Helpers;
using SmartSchool.API.Helpers.Http;
using SmartSchool.API.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IMapper _mapper;

        public StudentController(IStudentRepository repo, IMapper mapper)
        {
            _repository = repo;
            _mapper = mapper;
        }

        /// <summary>
        /// Return all students 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams parameters)
        {
            return Ok(_mapper.Map<RestListResponse<StudentDto>>(await _repository.GetAllStudents(parameters)));
        }

        /// <summary>
        /// Searches the student by Id and returns if it exists
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Student student = await _repository.GetStudentById(id);

            if (student == null) return BadRequest("The Student searched does not exists in our school");

            return Ok(_mapper.Map<StudentDto>(student));
        }


        /// <summary>
        ///  Searches the student by Name and returns if it exists
        /// </summary>
        /// <param name="name"></param>
        /// <param name="lastName"></param>
        /// <returns></returns>
        [HttpGet("ByName")]
        public async Task<IActionResult> GetByName(string name, string lastName)
        {
            Student student = await _repository.GetStudentByName(name, lastName);

            if (student == null) return BadRequest("The Student searched does not exists in our school");

            return Ok(_mapper.Map<StudentDto>(student));
        }

        /// <summary>
        /// Create new Student
        /// </summary>
        /// <param name="studentDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] StudentDto studentDto)
        {
            Student student = _mapper.Map<Student>(studentDto);
            _repository.Add<Student>(student);
            return Created($"/api/aluno/{student.Id}", _mapper.Map<StudentDto>(student));
        }
        
        /// <summary>
        /// Update the student data 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] StudentDto student)
        {
            Student studentFound = await _repository.GetStudentById(id);
            if (studentFound == null) return BadRequest("The Student searched does not exists in our school");

            _mapper.Map(student, studentFound);

            _repository.Update<Student>(studentFound);
            return Created($"/api/aluno/{student.Id}", _mapper.Map<StudentDto>(student));
        }

        /// <summary>
        /// Delete the student by Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Student studentFound = await _repository.GetStudentById(id);
            if (studentFound == null) return BadRequest("The Student searched does not exists in our school");

            _repository.Delete<Student>(studentFound);
            return Ok("Student deleted");
        }
    }
}
