using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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
