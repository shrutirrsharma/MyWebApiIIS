using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    // Define database tables
    public DbSet<Employee> Employees { get; set; }
    public DbSet<Product> Products { get; set; }
}
