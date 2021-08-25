using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Course : BaseModel
    {
        public Course(int id, string name) : base (id)
        {
            Name = name;
        }

        public string Name { get; set; }
        public IEnumerable<Subject> Subjects { get; set; }
    }
}
