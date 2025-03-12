// Application/Services/DoctorService.cs
using Core.Entities;
using Application.DTOs;
using Application.Interfaces;




namespace Application.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;

        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<DoctorDto>> GetAllDoctorsAsync()
        {
            var Doctors = await _repository.GetAllAsync();
            return Doctors.Select(dt => new DoctorDto
            {
                Id = dt.Id,
                Name = dt.Name,
                Email = dt.Email,
                DoctorTypeId = dt.DoctorTypeId,
                Department = dt.Department,
                Specialization = dt.Specialization,
                PhoneNumber = dt.PhoneNumber

            });
        }

        public async Task<DoctorDto> GetDoctorByIdAsync(int id)
        {
            var Doctor = await _repository.GetByIdAsync(id);
            if (Doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found");

            return new DoctorDto
            {
                Id = Doctor.Id,
                Name = Doctor.Name,
                Email = Doctor.Email,
                DoctorTypeId = Doctor.DoctorTypeId,
                Department = Doctor.Department,
                Specialization = Doctor.Specialization,
                PhoneNumber = Doctor.PhoneNumber

            };
        }

        public async Task<DoctorDto> CreateDoctorAsync(CreateDoctorDto createDto)
        {
            var Doctor = new Doctor
            {
                Name = createDto.Name,
                Email = createDto.Email,
                DoctorTypeId = createDto.DoctorTypeId,
                Department = createDto.Department,
                Specialization = createDto.Specialization,
                PhoneNumber = createDto.PhoneNumber

            };

            var created = await _repository.AddAsync(Doctor);
            
            return new DoctorDto
            {
                Id = created.Id,
                Name = created.Name,
                Email = created.Email,
                DoctorTypeId = created.DoctorTypeId,
                Department = created.Department,
                Specialization = created.Specialization,
                PhoneNumber = created.PhoneNumber

            };
        }

        public async Task UpdateDoctorAsync(int id, UpdateDoctorDto updateDto)
        {
            var Doctor = await _repository.GetByIdAsync(id);
            if (Doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found");

            Doctor.Name = updateDto.Name;
            Doctor.Email = updateDto.Email;
            Doctor.DoctorTypeId = updateDto.DoctorTypeId;
            Doctor.Department = updateDto.Department;
            Doctor.Specialization = updateDto.Specialization;
            Doctor.PhoneNumber = updateDto.PhoneNumber;


            await _repository.UpdateAsync(Doctor);
        }

        public async Task DeleteDoctorAsync(int id)
        {
            var Doctor = await _repository.GetByIdAsync(id);
            if (Doctor == null)
                throw new KeyNotFoundException($"Doctor with ID {id} not found");

            await _repository.DeleteAsync(id);
        }
    }
}