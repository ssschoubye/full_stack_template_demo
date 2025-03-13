using Core.Entities;
using Core.Interfaces;


public interface IUserRepository : IRepository<User> 
{
    Task<User?> GetByUsernameAsync(string username);
}