using AutoMapper;
using SmartSchool.API.DTOs;
using SmartSchool.API.Helpers.Extensions;
using SmartSchool.API.Models;

namespace SmartSchool.API.Helpers
{
    public class SmartSchoolProfile : Profile
    {
        public SmartSchoolProfile()
        {
            CreateMap<StudentDto, Student>();
            CreateMap<Student, StudentDto>()
                .ForMember(
                    destinationMember => destinationMember.Name,
                    memberOptions => memberOptions.MapFrom(src => $"{src.Name} {src.LastName}")
                )
                .ForMember(
                    destinationMember => destinationMember.Age,
                    memberOptions => memberOptions.MapFrom(src => src.BirthdayDate.GetCurrentAge())
                );
            CreateMap<RestListResponse<StudentDto>, RestListResponse<Student>>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<RestListResponse<TeacherDto>, RestListResponse<Teacher>>().ReverseMap();
        }
    }
}
