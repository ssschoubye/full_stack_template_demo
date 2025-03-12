using Core.Entities;

namespace Core.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    public interface IDoctorTypeRepository : IRepository<DoctorType> { }
    public interface IShiftTypeRepository : IRepository<ShiftType> { }
    public interface IDoctorRepository : IRepository<Doctor> { }
    public interface IUserRepository : IRepository<User> 
    {
        Task<User?> GetByUsernameAsync(string username);
    }
}