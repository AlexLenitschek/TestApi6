using Microsoft.EntityFrameworkCore;
using TestApi6.Models.Entities;

namespace TestApi6.Data
{
    public class TestApi6DbContext : DbContext
    {
        public TestApi6DbContext(DbContextOptions options) : base(options)
        {
        }

        protected TestApi6DbContext()
        {
        }

        public DbSet<Employee> Employees { get; set; }
    }
}
