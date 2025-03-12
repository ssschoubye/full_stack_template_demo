// Application/Services/ShiftTypeService.cs
using Core.Entities;
using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    public class ShiftTypeService : IShiftTypeService
    {
        private readonly IShiftTypeRepository _repository;

        public ShiftTypeService(IShiftTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ShiftTypeDto>> GetAllShiftTypesAsync()
        {
            var ShiftTypes = await _repository.GetAllAsync();
            return ShiftTypes.Select(dt => new ShiftTypeDto
            {
                Id = dt.Id,
                Name = dt.Name,
                StartTime = dt.StartTime,
                EndTime = dt.EndTime,
                Color = dt.Color
            });
        }

        public async Task<ShiftTypeDto> GetShiftTypeByIdAsync(int id)
        {
            var ShiftType = await _repository.GetByIdAsync(id);
            if (ShiftType == null)
                throw new KeyNotFoundException($"Shift type with ID {id} not found");

            return new ShiftTypeDto
            {
                Id = ShiftType.Id,
                Name = ShiftType.Name,
                StartTime = ShiftType.StartTime,
                EndTime = ShiftType.EndTime,
                Color = ShiftType.Color
            };
        }

        public async Task<ShiftTypeDto> CreateShiftTypeAsync(CreateShiftTypeDto createDto)
        {
            var ShiftType = new ShiftType
            {
                Name = createDto.Name,
                StartTime = createDto.StartTime,
                EndTime = createDto.EndTime,
                Color = createDto.Color
            };

            var created = await _repository.AddAsync(ShiftType);
            
            return new ShiftTypeDto
            {
                Id = created.Id,
                Name = created.Name,
                StartTime = created.StartTime,
                EndTime = created.EndTime,
                Color = created.Color
            };
        }

        public async Task UpdateShiftTypeAsync(int id, UpdateShiftTypeDto updateDto)
        {
            var ShiftType = await _repository.GetByIdAsync(id);
            if (ShiftType == null)
                throw new KeyNotFoundException($"Shift type with ID {id} not found");

            ShiftType.Name = updateDto.Name;
            ShiftType.StartTime = updateDto.StartTime;
            ShiftType.EndTime = updateDto.EndTime;
            ShiftType.Color = updateDto.Color;

            await _repository.UpdateAsync(ShiftType);
        }

        public async Task DeleteShiftTypeAsync(int id)
        {
            var ShiftType = await _repository.GetByIdAsync(id);
            if (ShiftType == null)
                throw new KeyNotFoundException($"Shift type with ID {id} not found");

            await _repository.DeleteAsync(id);
        }

        public async Task<ShiftTypeDto> GetByColorAsync(string color)
        {
            var ShiftType = await _repository.GetByColorAsync(color);
            if (ShiftType == null)
                throw new KeyNotFoundException($"Shift type with color {color} not found");

            return new ShiftTypeDto
            {
                Id = ShiftType.Id,
                Name = ShiftType.Name,
                StartTime = ShiftType.StartTime,
                EndTime = ShiftType.EndTime,
                Color = ShiftType.Color
            };
        }
    }
}