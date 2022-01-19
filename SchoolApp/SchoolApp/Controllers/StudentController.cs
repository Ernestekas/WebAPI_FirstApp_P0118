using Microsoft.AspNetCore.Mvc;
using SchoolApp.Dtos;
using SchoolApp.Models;
using SchoolApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly StudentService _studentService;

        public StudentController(StudentService studentService)
        {
            _studentService = studentService;
        }

        [HttpPost]
        public void Create(StudentDto newStudent)
        {
            _studentService.Create(newStudent);
        }

        [HttpGet]
        public List<StudentDto> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{id}")]
        public StudentDto GetById(int id)
        {
            return _studentService.GetById(id);
        }

        [HttpDelete("{id}")]
        public void Remove(int id)
        {
            _studentService.Remove(id);
        }

        [HttpPut("{id}")]
        public void Update(int id, [FromBody] StudentDto studentDto)
        {
            _studentService.Update(id, studentDto);
        }
    }
}
