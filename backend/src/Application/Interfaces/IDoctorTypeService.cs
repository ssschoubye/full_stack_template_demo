using Application.DTOs;

namespace Application.Interfaces

{
    public interface IDoctorTypeService
    {
        Task<IEnumerable<DoctorTypeDto>> GetAllDoctorTypesAsync();
        Task<DoctorTypeDto> GetDoctorTypeByIdAsync(int id);
        Task<DoctorTypeDto> CreateDoctorTypeAsync(CreateDoctorTypeDto doctorTypeDto);
        Task UpdateDoctorTypeAsync(int id, UpdateDoctorTypeDto doctorTypeDto);
        Task DeleteDoctorTypeAsync(int id);
        Task<DoctorTypeDto> GetByColorAsync(string color);
    }
}