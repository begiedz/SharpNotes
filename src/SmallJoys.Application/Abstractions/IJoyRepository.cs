using SmallJoys.Domain.Entities;

namespace SmallJoys.Application.Abstractions;

public interface IJoyRepository
{
    Task<IReadOnlyList<Joy>> GetAllAsync();
    Task<Joy?> GetByIdAsync(int id);
    Task<Joy> AddAsync(Joy joy);
    Task<bool> UpdateAsync(Joy joy);
    Task<bool> DeleteAsync(int id);
}

