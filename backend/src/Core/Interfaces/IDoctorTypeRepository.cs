using Core.Entities;
using Core.Interfaces;


public interface IDoctorTypeRepository : IRepository<DoctorType> 
{
    Task<DoctorType?> GetByColorAsync(string color);
}