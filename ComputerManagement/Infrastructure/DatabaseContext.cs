using ComputerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerManagement.Infrastructure;

public class DatabaseContext(DbContextOptions opt) : DbContext(opt)
{
    public DbSet<Component> Components { get; set; }
    public DbSet<ComponentManufacturer> ComponentManufacturers { get; set; }
    public DbSet<ComponentType> ComponentTypes { get; set; }
    public DbSet<Pc> Pcs { get; set; }
    public DbSet<PcComponent> PcComponents { get; set; }
}