using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ComputerManagement.Models;

[Table("Components")]
public class Component
{
    [Key] 
    [Column(TypeName = "char(10)")]
    public string Code { get; set; } = string.Empty;

    [MaxLength(300)] 
    public string Name { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    [ForeignKey(nameof(ComponentManufacturer))]
    public int ComponentManufacturerId { get; set; }
    
    [ForeignKey(nameof(ComponentType))]
    public int ComponentTypeId { get; set; }

    public ComponentManufacturer ComponentManufacturer { get; set; } = null!;

    public ComponentType ComponentType { get; set; } = null!;

    public ICollection<PcComponent> PcComponents { get; set; } = [];
}