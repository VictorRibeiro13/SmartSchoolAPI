using System;

namespace SmartSchool.API.Models
{
    public class BaseModel
    {
        public BaseModel(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}
