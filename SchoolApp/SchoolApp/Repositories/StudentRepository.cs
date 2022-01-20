using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Repositories
{
    public class StudentRepository : RepositoryBase<Student>
    {
        public StudentRepository(DataContext context) : base(context) { }
    }
}
