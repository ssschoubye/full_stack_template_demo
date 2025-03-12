// Application/Services/DoctorTypeService.cs
using Core.Entities;
using Application.DTOs;
using Application.Interfaces;

namespace Application.Services
{
    public class DoctorTypeService : IDoctorTypeService
    {
        private readonly IDoctorTypeRepository _repository;

        public DoctorTypeService(IDoctorTypeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DoctorTypeDto>> GetAllDoctorTypesAsync()
        {
            var doctorTypes = await _repository.GetAllAsync();
            return doctorTypes.Select(dt => new DoctorTypeDto
            {
                Id = dt.Id,
                Name = dt.Name,
                Color = dt.Color
            });
        }

        public async Task<DoctorTypeDto> GetDoctorTypeByIdAsync(int id)
        {
            var doctorType = await _repository.GetByIdAsync(id);
            if (doctorType == null)
                throw new KeyNotFoundException($"Doctor type with ID {id} not found");

            return new DoctorTypeDto
            {
                Id = doctorType.Id,
                Name = doctorType.Name,
                Color = doctorType.Color
            };
        }

        public async Task<DoctorTypeDto> CreateDoctorTypeAsync(CreateDoctorTypeDto createDto)
        {
            var doctorType = new DoctorType
            {
                Name = createDto.Name,
                Color = createDto.Color
            };

            var created = await _repository.AddAsync(doctorType);
            
            return new DoctorTypeDto
            {
                Id = created.Id,
                Name = created.Name,
                Color = created.Color
            };
        }

        public async Task UpdateDoctorTypeAsync(int id, UpdateDoctorTypeDto updateDto)
        {
            var doctorType = await _repository.GetByIdAsync(id);
            if (doctorType == null)
                throw new KeyNotFoundException($"Doctor type with ID {id} not found");

            doctorType.Name = updateDto.Name;
            doctorType.Color = updateDto.Color;

            await _repository.UpdateAsync(doctorType);
        }

        public async Task DeleteDoctorTypeAsync(int id)
        {
            var doctorType = await _repository.GetByIdAsync(id);
            if (doctorType == null)
                throw new KeyNotFoundException($"Doctor type with ID {id} not found");

            await _repository.DeleteAsync(id);
        }

        public async Task<DoctorTypeDto> GetByColorAsync(string color)
        {
            var doctorType = await _repository.GetByColorAsync(color);
            if (doctorType == null)
                throw new KeyNotFoundException($"Doctor type with color {color} not found");

            return new DoctorTypeDto
            {
                Id = doctorType.Id,
                Name = doctorType.Name,
                Color = doctorType.Color
            };
        }
    }
}