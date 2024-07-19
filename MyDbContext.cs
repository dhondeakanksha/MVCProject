using Microsoft.EntityFrameworkCore;
using MVCProject.Models;
namespace MVCProject.DBContext
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) :base(options)
        {

        }

        public  DbSet<Designation> Designation { get; set; }
        public DbSet<DesignationGrade> DesignationGrade {  get; set; }
        public DbSet <Employee> Employee {  get; set; }

    }
}
