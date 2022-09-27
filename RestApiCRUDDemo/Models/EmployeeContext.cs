

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;

namespace RestApiCRUDDemo.Models


{
    public class EmployeeContext:DbContext
    {
        public EmployeeContext(DbContextOptions <EmployeeContext> options):base(options)
        { 
        

        
        }

        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }

    }
}
