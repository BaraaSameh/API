using Microsoft.EntityFrameworkCore;

namespace ITI.Models
{
    public class ITIContext: DbContext
    {
        public ITIContext(DbContextOptions<ITIContext> options) : base(options)
        {
        }
        public DbSet<Department> Departments { get; set; }
    }
}
