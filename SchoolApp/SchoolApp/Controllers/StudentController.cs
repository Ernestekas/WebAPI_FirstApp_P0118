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
        private readonly SchoolService _schoolService;

        public StudentController(StudentService studentService, SchoolService schoolService)
        {
            _studentService = studentService;
            _schoolService = schoolService;
        }

        [HttpPost]
        public IActionResult Create(StudentDto newStudent)
        {
            TryValidateModel(new Student() { Name = newStudent.StudentName });
            if (!ModelState.IsValid)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Validation Failed",
                    Errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };

                return BadRequest(errorModel);
            }

            try
            {
                _schoolService.TryValidateById(newStudent.SchoolId);

                int studentId = _studentService.Create(newStudent);

                return Created($"~/Student/{studentId}", _studentService.GetById(studentId));
            }
            catch (Exception ex)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Creation Failed",
                    Errors = ex.Message
                };

                return NotFound(errorModel);
            }
        }

        [HttpGet]
        public List<StudentDto> GetAll()
        {
            return _studentService.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                StudentDto studentDto = _studentService.GetById(id);
                return Ok(studentDto);
            }
            catch (Exception ex)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Selection Failed",
                    Errors = ex.Message
                };
                return NotFound(errorModel);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            try
            {
                _studentService.Remove(id);
                return Ok("Student Removed");
            }
            catch (Exception ex)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Deletion Failed",
                    Errors = ex.Message
                };
                return BadRequest(errorModel);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] StudentDto studentDto)
        {
            TryValidateModel(new Student() { Name = studentDto.StudentName });
            if (!ModelState.IsValid)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Validation Failed",
                    Errors = string.Join("; ", ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage))
                };
                return BadRequest(errorModel);
            }

            try
            {
                _studentService.Update(id, studentDto);
                return Ok("Student Data Updated");
            }
            catch (Exception ex)
            {
                ErrorModel errorModel = new ErrorModel()
                {
                    Message = "Update Failed",
                    Errors = ex.Message
                };
                return BadRequest(errorModel);
            }
        }
    }
}
