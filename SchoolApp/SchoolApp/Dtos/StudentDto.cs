using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Dtos
{
    public class StudentDto
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Sex{ get; set; }
        public int SchoolId { get; set; }
    }
}
