using SchoolApp.Data;
using SchoolApp.Models;

namespace SchoolApp.Repositories
{
    public class SexRepository : RepositoryBase<Sex>
    {
        public SexRepository(DataContext context) : base(context) { }
    }
}
