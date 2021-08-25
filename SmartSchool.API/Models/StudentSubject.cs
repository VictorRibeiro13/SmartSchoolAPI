
using System;

namespace SmartSchool.API.Models
{
    public class StudentSubject
    {
        public StudentSubject() {}
        public StudentSubject(int studentId, int subjectId)
        {
            StudentId = studentId;
            SubjectId = subjectId;
        }

        public DateTime InitialDate { get; set; } = DateTime.Now;
        public DateTime? EndDate { get; set; } = null;
        public int? Grade { get; set; } = 0;
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public Student Student { get; set; }
        public Subject Subject { get; set; }
    }
}
