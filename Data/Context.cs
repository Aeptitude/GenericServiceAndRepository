using System.Data.Entity;
using Models;

namespace Data
{
    public class Context : DbContext
    {
        public Context() : base("DefaultConnectionString") { }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
    }
}
