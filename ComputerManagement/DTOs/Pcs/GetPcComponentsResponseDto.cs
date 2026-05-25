namespace ComputerManagement.DTOs.Pcs;

public class GetPcComponentsResponseDto
{
    public string Code { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;

    public int Amount { get; set; }
}