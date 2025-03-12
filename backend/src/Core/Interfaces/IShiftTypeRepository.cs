using Core.Entities;
using Core.Interfaces;


public interface IShiftTypeRepository : IRepository<ShiftType> 
{
    Task<ShiftType?> GetByColorAsync(string color);
}