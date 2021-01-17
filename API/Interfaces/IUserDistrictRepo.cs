using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserDistrictRepo
    {
         Task AddAsync(UserDistrict userDistrict);
         void Delete(UserDistrict userDistrict);
         Task<bool> SaveAllAsync();
         Task<UserDistrict> GetSingleAsync(int userId, int districtId);
         Task<IEnumerable<UserDistrict>> GetAllAsync();
         Task<IEnumerable<District>> GetForUserAsync(int userId);
    }
}