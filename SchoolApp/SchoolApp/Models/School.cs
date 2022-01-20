using System;
using System.Collections.Generic;

namespace SchoolApp.Models
{
    public class School : Entity
    {
        public DateTime Created { get; set; }
        public List<Student> Students { get; set; }
    }
}
