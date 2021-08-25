using System;
using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Teacher : BaseModel
    {
        public Teacher(
            int id,
            int registration,
            string name,
            string lastName
        ) : base(id)
        {
            Name = name;
            Registration = registration;
            LastName = lastName;
        }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public int Registration { get; set; }
        public DateTime InitialDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public bool Active { get; set; } = true;
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
