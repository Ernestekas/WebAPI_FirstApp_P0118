using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repositories
{
    public class StudentRepository : RepositoryBase<Student>
    {
        public StudentRepository(DataContext context) : base(context) { }
    }
}
