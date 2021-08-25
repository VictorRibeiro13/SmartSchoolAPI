using System.Collections.Generic;

namespace SmartSchool.API.Models
{
    public class Subject : BaseModel
    {
        public Subject(int id, string name, int teacherId,int courseId) : base(id)
        {
            Name = name;
            TeacherId = teacherId;
            CourseId = courseId;
        }

        public string Name { get; set; }
        public int Workload { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int? PrerequisiteId { get; set; } = null;
        public Teacher Teacher { get; set; }
        public Course Course { get; set; }
        public Subject Prerequisite { get; set; }
        public IEnumerable<StudentSubject> StudentsSubjects { get; set; }
    }
}


