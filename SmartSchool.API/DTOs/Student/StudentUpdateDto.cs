using System;

namespace SmartSchool.API.DTOs
{
    public class StudentUpdateDto
    {
        public int Id { get; set; }
        public int Registration { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthdayDate { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool Active { get; set; } = true;
        public DateTime UpdatedAt { get; set; }
    }
}
