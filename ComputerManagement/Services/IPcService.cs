using ComputerManagement.DTOs.Pcs;

namespace ComputerManagement.Services;

public interface IPcService
{
    Task<IEnumerable<GetPcResponseDto>> GetAll();

    Task<IEnumerable<GetPcComponentsResponseDto>?> GetComponents(int id);

    Task<GetPcResponseDto> Create(CreatePcRequestDto dto);

    Task<bool> Update(int id, UpdatePcRequestDto dto);

    Task<bool> Delete(int id);
}