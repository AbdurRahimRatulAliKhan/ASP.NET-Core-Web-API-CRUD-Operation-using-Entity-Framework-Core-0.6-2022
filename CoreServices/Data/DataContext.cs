using Microsoft.EntityFrameworkCore;

namespace CoreServices.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<DevsfairEmployee> DevsfairEmployees { get; set; }
    }
}
