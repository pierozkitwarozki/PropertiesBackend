using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserPropertyService
    {
        Task<IAsyncResult> AddAsync(UserPropertyToAdd userProperty);
        Task<IAsyncResult> DeleteAsync(int userId, int propertyId);
        Task<UserProperty> GetSingleAsync(int userId, int propertyId);
        Task<IEnumerable<UserProperty>> GetAllAsync();
        Task<IEnumerable<PropertyToReturn>> GetForUserAsync(int userId);
    }
}