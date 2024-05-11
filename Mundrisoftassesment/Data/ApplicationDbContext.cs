using Microsoft.EntityFrameworkCore;
using Mundrisoftassesment.Models;

namespace Mundrisoftassesment.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            :base(options)
        {
                
        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Users> Users { get; set; }
       
       
    }
}
