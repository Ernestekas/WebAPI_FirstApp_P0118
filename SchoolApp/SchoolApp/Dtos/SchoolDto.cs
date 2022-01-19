using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Dtos
{
    public class SchoolDto
    {
        [Required(ErrorMessage = "Name is required.")]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters long.")]
        public string SchoolName{ get; set; }
        public DateTime SchoolCreated { get; set; }
        public List<StudentDto> Students { get; set; }
    }
}
