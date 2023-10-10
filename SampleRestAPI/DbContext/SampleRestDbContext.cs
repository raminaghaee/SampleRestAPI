using Microsoft.EntityFrameworkCore;
using SampleRestAPI.Entities;

namespace SampleRestAPI.DbContext;

public class SampleRestDbContext : Microsoft.EntityFrameworkCore.DbContext
{
    public DbSet<Employee> Employees{ get; set; }
    public SampleRestDbContext(DbContextOptions options) : base(options)
    {
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SampleRestDbContext).Assembly);
    }
}
