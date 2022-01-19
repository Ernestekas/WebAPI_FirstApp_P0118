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

        public SchoolService(SchoolRepository schoolRepository)
        {
            _schoolRepository = schoolRepository;
        }

        public void Create(string name)
        {
            School newSchool = new School()
            {
                Name = name,
                Created = DateTime.Now,
            };

            _schoolRepository.Create(newSchool);
        }

        public List<School> GetAll()
        {
            return _schoolRepository.GetAll();
        }

        public School GetById(int id)
        {
            return _schoolRepository.GetById(id);
        }

        public void Update(int id, string newName)
        {
            School school = _schoolRepository.GetById(id);
            school.Name = newName;

            _schoolRepository.Update(school);
        }

        public void Remove(int id)
        {
            _schoolRepository.Remove(id);
        }
    }
}
