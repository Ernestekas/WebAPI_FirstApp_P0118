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
        private SchoolService _schoolService;

        public StudentService(StudentRepository studentRepository, SchoolService schoolService)
        {
            _studentRepository = studentRepository;
            _schoolService = schoolService;
        }

        public int Create(StudentDto newStudent)
        {
            Student student = new Student()
            {
                Name = newStudent.StudentName,
                Sex = newStudent.Sex,
                SchoolId = newStudent.SchoolId
            };

            return _studentRepository.Create(student);
        }

        public void Update(int id, StudentDto studentDto)
        {
            Student student = _studentRepository.GetById(id);

            TryValidateStudent(student, "There is no student with this Id");

            student.Name = studentDto.StudentName;
            student.SchoolId = studentDto.SchoolId;

            _schoolService.TryValidateById(student.SchoolId);

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

            TryValidateStudent(student, "There is no student with this Id");
            
            return new StudentDto()
            {
                StudentName = student.Name,
                Sex = student.Sex,
                SchoolId = student.SchoolId
            };
        }

        public void Remove(int id)
        {
            Student student = _studentRepository.GetById(id);

            TryValidateStudent(student, "There is no such student with this Id");

            _studentRepository.Remove(id);
        }

        private void TryValidateStudent(Student student, string errorMessage)
        {
            if(student == null)
            {
                throw new Exception(errorMessage);
            }
        }
    }
}
