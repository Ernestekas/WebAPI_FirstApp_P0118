using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Dtos
{
    public class SchoolDto
    {
        public string SchoolName{ get; set; }
        public DateTime SchoolCreated { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
