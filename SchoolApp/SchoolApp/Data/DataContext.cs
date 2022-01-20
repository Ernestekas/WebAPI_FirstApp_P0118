using Microsoft.EntityFrameworkCore;
using SchoolApp.Models;

namespace SchoolApp.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Sex> Sexes { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
