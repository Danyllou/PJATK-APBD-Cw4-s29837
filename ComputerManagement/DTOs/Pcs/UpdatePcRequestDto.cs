using System.ComponentModel.DataAnnotations;

namespace ComputerManagement.DTOs.Pcs;

public class UpdatePcRequestDto
{
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;

    public float Weight { get; set; }

    public int Warranty { get; set; }

    public DateTime CreatedAt { get; set; }

    public int Stock { get; set; }
}