using Microsoft.EntityFrameworkCore;

namespace EmployeesAndGroups.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
