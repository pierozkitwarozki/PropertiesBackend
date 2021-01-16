using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IPropertyService
    {
        Task<PropertyToReturn> AddAsync(PropertyToAdd propertyToAdd); 
        Task<IAsyncResult> DeleteAsync(int propertyId);
        Task<IEnumerable<PropertyToReturn>> GetAllAsync();
        Task<PropertyToReturn> GetAsync(int propertyId);
        Task<IEnumerable<PropertyToReturn>> GetForDistrictAsync(int districtId);
    }
}