using Microsoft.EntityFrameworkCore;
using SIGA.Domain.Entities;
using System.Reflection;

namespace SIGA.Infrastructure.Context;
public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    public DbSet<ApplicationUser> Users { get; set; }
    public DbSet<Claim> Claims { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<DatabaseAccess> DatabaseAccesses { get; set; }
    public DbSet<DatabaseType> DatabaseTypes { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Vpn> Vpns { get; set; }
    public DbSet<VpnAccess> VpnAccesses { get; set; }
}
