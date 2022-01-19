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
    }
}
