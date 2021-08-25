using System;

namespace SmartSchool.API.DTOs
{
    public class BaseDto
    {
        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}
