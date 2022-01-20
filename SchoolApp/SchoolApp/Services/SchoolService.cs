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
    public class SchoolService
    {
        private SchoolRepository _schoolRepository;
        private StudentRepository _studentRepository;
        private SexRepository _sexRepository;

        public SchoolService(SchoolRepository schoolRepository, StudentRepository studentRepository, SexRepository sexRepository)
        {
            _schoolRepository = schoolRepository;
            _studentRepository = studentRepository;
            _sexRepository = sexRepository;
        }

        public int Create(string name)
        {
            School newSchool = new School()
            {
                Name = name,
                Created = DateTime.Now,
            };

            return _schoolRepository.Create(newSchool);
        }

        public List<SchoolDto> GetAll()
        {
            List<SchoolDto> schoolDtos = new List<SchoolDto>();
            List<School> schools = _schoolRepository.GetAllIncluded();
            
            foreach(var school in schools)
            {
                SchoolDto schoolDto = new SchoolDto()
                {
                    SchoolName = school.Name,
                    SchoolCreated = school.Created,
                    Students = ParseToDto(school.Students)
                };

                schoolDtos.Add(schoolDto);
            }

            return schoolDtos;
        }

        public SchoolDto GetById(int id)
        {
            School school = _schoolRepository.GetByIdIncluded(id);

            TryValidateSchool(school, "No school was found.");

            SchoolDto schoolDto = new SchoolDto()
            {
                SchoolName= school.Name,
                SchoolCreated= school.Created,
                Students = ParseToDto(school.Students)
            };

            return schoolDto;
        }

        public void Update(int id, string newName)
        {
            School school = _schoolRepository.GetById(id);

            TryValidateSchool(school, "There is no school with this Id.");

            school.Name = newName;
            _schoolRepository.Update(school);
        }

        public void Remove(int id)
        {
            School school = _schoolRepository.GetById(id);

            TryValidateSchool(school, "There is no school with this Id.");

            _schoolRepository.Remove(id);
        }

        public void TryValidateById(int id)
        {
            School school = _schoolRepository.GetById(id);
            TryValidateSchool(school, "There is no school with this Id.");
        }

        private List<StudentDto> ParseToDto(List<Student> students)
        {
            List<StudentDto> studentDtos = new List<StudentDto>();

            foreach(var student in students)
            {
                StudentDto studentDto = new StudentDto()
                {
                    StudentName = student.Name,
                    SexName = _sexRepository.GetById(student.SexId).Name,
                    SchoolName = _schoolRepository.GetById(student.SchoolId).Name
                };
                studentDtos.Add(studentDto);
            }

            return studentDtos;
        }

        private void TryValidateSchool(School school, string errorMessage)
        {
            if(school == null)
            {
                throw new Exception(errorMessage);
            }
        }
    }
}
