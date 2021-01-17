using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserDistrictService
    {
        Task<IAsyncResult> AddAsync(UserDistrictToAdd userDistrict);
        Task<IAsyncResult> DeleteAsync(int userId, int districtId);
        Task<UserDistrict> GetSingleAsync(int userId, int districtId);
        Task<IEnumerable<UserDistrict>> GetAllAsync();
        Task<IEnumerable<District>> GetForUserAsync(int userId);
    }
}