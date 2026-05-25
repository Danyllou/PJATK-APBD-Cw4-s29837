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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ComponentManufacturer>().HasData(
            new ComponentManufacturer
            {
                Id = 1,
                Abbreviation = "AMD",
                FullName = "Advanced Micro Devices",
                FoundationDate = new DateTime(1969, 5, 1)
            },
            new ComponentManufacturer
            {
                Id = 2,
                Abbreviation = "INTEL",
                FullName = "Intel Corporation",
                FoundationDate = new DateTime(1968, 7, 18)
            },
            new ComponentManufacturer
            {
                Id = 3,
                Abbreviation = "NVIDIA",
                FullName = "NVIDIA Corporation",
                FoundationDate = new DateTime(1993, 4, 5)
            });

        modelBuilder.Entity<ComponentType>().HasData(
            new ComponentType
            {
                Id = 1,
                Abbreviation = "CPU",
                Name = "Processor"
            },
            new ComponentType
            {
                Id = 2,
                Abbreviation = "GPU",
                Name = "Graphics Card"
            },
            new ComponentType
            {
                Id = 3,
                Abbreviation = "RAM",
                Name = "Memory"
            });

        modelBuilder.Entity<Component>().HasData(
            new Component
            {
                Code = "CPU0000001",
                Name = "Ryzen 7 7800X3D",
                Description = "Gaming processor",
                ComponentManufacturerId = 1,
                ComponentTypeId = 1
            },
            new Component
            {
                Code = "GPU0000001",
                Name = "RTX 4080",
                Description = "Graphics card",
                ComponentManufacturerId = 3,
                ComponentTypeId = 2
            },
            new Component
            {
                Code = "RAM0000001",
                Name = "DDR5 32GB",
                Description = "Memory kit",
                ComponentManufacturerId = 2,
                ComponentTypeId = 3
            });

        modelBuilder.Entity<Pc>().HasData(
            new Pc
            {
                Id = 1,
                Name = "Gaming Beast X",
                Weight = 12.5f,
                Warranty = 36,
                CreatedAt = new DateTime(2026, 5, 8),
                Stock = 5
            },
            new Pc
            {
                Id = 2,
                Name = "Office Mini",
                Weight = 4.2f,
                Warranty = 24,
                CreatedAt = new DateTime(2026, 4, 15),
                Stock = 12
            },
            new Pc
            {
                Id = 3,
                Name = "Workstation Pro",
                Weight = 9.5f,
                Warranty = 48,
                CreatedAt = new DateTime(2026, 3, 10),
                Stock = 3
            });

        modelBuilder.Entity<PcComponent>().HasData(
            new PcComponent
            {
                PcId = 1,
                ComponentCode = "CPU0000001",
                Amount = 1
            },
            new PcComponent
            {
                PcId = 1,
                ComponentCode = "GPU0000001",
                Amount = 1
            },
            new PcComponent
            {
                PcId = 1,
                ComponentCode = "RAM0000001",
                Amount = 2
            });
        base.OnModelCreating(modelBuilder);
    }
}