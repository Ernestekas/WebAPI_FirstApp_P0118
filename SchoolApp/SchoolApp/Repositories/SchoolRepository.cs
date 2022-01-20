﻿using Microsoft.EntityFrameworkCore;
using SchoolApp.Data;
using SchoolApp.Models;
using System.Collections.Generic;
using System.Linq;

namespace SchoolApp.Repositories
{
    public class SchoolRepository : RepositoryBase<School>
    {
        public SchoolRepository(DataContext context) : base(context) { }

        public List<School> GetAllIncluded()
        {
            return _context.Schools.Include(s => s.Students).ToList();
        }

        public School GetByIdIncluded(int id)
        {
            return _context.Schools.Include(s => s.Students).FirstOrDefault(s => s.Id == id);
        }
    }
}
