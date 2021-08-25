using System;

namespace SmartSchool.API.DTOs
{
    public class TeacherRegisterDto
    {
        public int Registration { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public bool Active { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
