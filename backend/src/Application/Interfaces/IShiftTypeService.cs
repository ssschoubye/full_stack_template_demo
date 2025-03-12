using Application.DTOs;

namespace Application.Interfaces

{
    public interface IShiftTypeService
    {
        Task<IEnumerable<ShiftTypeDto>> GetAllShiftTypesAsync();
        Task<ShiftTypeDto> GetShiftTypeByIdAsync(int id);
        Task<ShiftTypeDto> CreateShiftTypeAsync(CreateShiftTypeDto ShiftTypeDto);
        Task UpdateShiftTypeAsync(int id, UpdateShiftTypeDto ShiftTypeDto);
        Task DeleteShiftTypeAsync(int id);
        Task<ShiftTypeDto> GetByColorAsync(string color);
    }
}