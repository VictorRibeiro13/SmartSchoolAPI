using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SmartSchool.API.DTOs;
using SmartSchool.API.Helpers;
using SmartSchool.API.Models;
using SmartSchool.API.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SmartSchool.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly ITeacherRepository _repository;
        private readonly IMapper _mapper;

        public TeacherController(ITeacherRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <summary>
        /// Returns all Teachers
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] PageParams parameters)
        {
            return Ok(_mapper.Map<RestListResponse<TeacherDto>>(await _repository.GetAllTeachers(parameters)));
        }

        /// <summary>
        /// Create a new Teacher
        /// </summary>
        /// <param name="teacherDto"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] TeacherRegisterDto teacherDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherDto);
            _repository.Add<Teacher>(teacher);
            return Created($"api/teacher/{teacher.Id}", _mapper.Map<TeacherDto>(teacher));
        }

    }   

}
