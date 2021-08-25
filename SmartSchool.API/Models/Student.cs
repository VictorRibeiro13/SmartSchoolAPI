using System;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Student : BaseModel
    {

        public Student(int id, int registration, string name, string lastName, string phone, DateTime birthdayDate, bool active = true) : base(id)
        {
            Registration = registration;
            Name = name;
            LastName = lastName;
            Phone = phone;
            BirthdayDate = birthdayDate;
            Active = active;
        }

        public int Registration { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public DateTime BirthdayDate { get; set; }
        public DateTime InitialDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<StudentSubject> StudentsSubjects { get; set; }
    }
}
