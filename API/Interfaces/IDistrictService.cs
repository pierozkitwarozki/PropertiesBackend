using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IDistrictService
    {
         Task<District> AddAsync(DistrictToAdd districtToAdd); 
         Task<IAsyncResult> DeleteAsync(int districtId);
         Task<IEnumerable<District>> GetAllAsync();
         Task<District> GetAsync(int districtId);
         
    }
}