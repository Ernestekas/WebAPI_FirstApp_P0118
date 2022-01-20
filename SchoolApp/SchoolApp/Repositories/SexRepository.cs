using SchoolApp.Data;
using SchoolApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolApp.Repositories
{
    public class SexRepository : RepositoryBase<Sex>
    {
        public SexRepository(DataContext context) : base(context) { }
    }
}
