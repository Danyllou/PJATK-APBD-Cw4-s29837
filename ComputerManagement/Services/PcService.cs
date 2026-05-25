using ComputerManagement.DTOs.Pcs;
using ComputerManagement.Infrastructure;
using ComputerManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace ComputerManagement.Services;

public class PcService(DatabaseContext context) : IPcService
{
    public async Task<IEnumerable<GetPcResponseDto>> GetAll()
    {
        return await context.Pcs
            .Select(x => new GetPcResponseDto
            {
                Id = x.Id,
                Name = x.Name,
                Weight = x.Weight,
                Warranty = x.Warranty,
                CreatedAt = x.CreatedAt,
                Stock = x.Stock
            })
            .ToListAsync();
    }

    public async Task<IEnumerable<GetPcComponentsResponseDto>?> GetComponents(int id)
    {
        var exists = await context.Pcs
            .AnyAsync(x => x.Id == id);

        if (!exists)
            return null;

        return await context.PcComponents
            .Where(x => x.PcId == id)
            .Select(x => new GetPcComponentsResponseDto
            {
                Code = x.Component.Code,
                Name = x.Component.Name,
                Amount = x.Amount
            })
            .ToListAsync();
    }

    public async Task<GetPcResponseDto> Create(CreatePcRequestDto dto)
    {
        var pc = new Pc
        {
            Name = dto.Name,
            Weight = dto.Weight,
            Warranty = dto.Warranty,
            CreatedAt = dto.CreatedAt,
            Stock = dto.Stock
        };

        context.Pcs.Add(pc);

        await context.SaveChangesAsync();

        return new GetPcResponseDto
        {
            Id = pc.Id,
            Name = pc.Name,
            Weight = pc.Weight,
            Warranty = pc.Warranty,
            CreatedAt = pc.CreatedAt,
            Stock = pc.Stock
        };
    }

    public async Task<bool> Update(int id, UpdatePcRequestDto dto)
    {
        var pc = await context.Pcs
            .FirstOrDefaultAsync(x => x.Id == id);

        if (pc is null)
            return false;

        pc.Name = dto.Name;
        pc.Weight = dto.Weight;
        pc.Warranty = dto.Warranty;
        pc.CreatedAt = dto.CreatedAt;
        pc.Stock = dto.Stock;

        await context.SaveChangesAsync();

        return true;
    }

    public async Task<bool> Delete(int id)
    {
        var pc = await context.Pcs
            .FirstOrDefaultAsync(x => x.Id == id);

        if (pc is null)
            return false;

        context.Pcs.Remove(pc);

        await context.SaveChangesAsync();

        return true;
    }
}