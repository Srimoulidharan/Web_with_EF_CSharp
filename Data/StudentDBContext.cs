using Microsoft.EntityFrameworkCore;
using Student_with_EF.Models;

namespace Student_with_EF.Data
{
    public class StudentDBContext:DbContext
    {
        public StudentDBContext(DbContextOptions<StudentDBContext> options):base (options) { }
        public DbSet<Student> student {  get; set; }

    }
}
