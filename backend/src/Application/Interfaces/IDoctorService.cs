using Application.DTOs;

namespace Application.Interfaces

{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync();
        Task<DoctorDto> GetDoctorByIdAsync(int id);
        Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto DoctorDto);
        Task UpdateDoctorAsync(int id, UpdateDoctorDto DoctorDto);
        Task DeleteDoctorAsync(int id);
    }
}