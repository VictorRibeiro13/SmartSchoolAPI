
using System;

namespace SmartSchool.API.DTOs
{
    public class StudentDto
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public int Age { get; set; }
        public bool Active { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
