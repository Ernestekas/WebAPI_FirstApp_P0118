using SchoolApp.Dtos;
using SchoolApp.Models;
using SchoolApp.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Services
{
    public class StudentService
    {
        private StudentRepository _studentRepository;

        public StudentService(StudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public void Create(StudentDto newStudent)
        {
            Student student = new Student()
            {
                Name = newStudent.StudentName,
                Sex = newStudent.Sex,
                SchoolId = newStudent.SchoolId
            };

            _studentRepository.Create(student);
        }

        public void Update(int id, StudentDto studentDto)
        {
            Student student = _studentRepository.GetById(id);
            student.Name = studentDto.StudentName;
            student.SchoolId = studentDto.SchoolId;

            _studentRepository.Update(student);
        }

        public List<StudentDto> GetAll()
        {
            List<StudentDto> studentDtos = new List<StudentDto>();
            List<Student> students = _studentRepository.GetAll();

            foreach(var student in students)
            {
                StudentDto studentDto = new StudentDto()
                {
                    StudentName = student.Name,
                    Sex = student.Sex,
                    SchoolId=student.SchoolId
                };
                studentDtos.Add(studentDto);
            }

            return studentDtos;
        }

        public StudentDto GetById(int id)
        {
            Student student = _studentRepository.GetById(id);
            return new StudentDto()
            {
                StudentName = student.Name,
                Sex = student.Sex,
                SchoolId = student.SchoolId
            };
        }

        public void Remove(int id)
        {
            _studentRepository.Remove(id);
        }
    }
}
