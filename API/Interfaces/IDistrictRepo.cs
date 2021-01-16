using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IDistrictRepo
    {
         Task AddAsync(District district);
         void Delete(District district);
         Task<bool> SaveAllAsync();
         Task<District> GetSingleAsync(int districtId);
         Task<IEnumerable<District>> GetAllAsync();
    }
}