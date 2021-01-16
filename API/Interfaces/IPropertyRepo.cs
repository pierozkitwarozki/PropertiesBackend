using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IPropertyRepo
    {
         Task AddAsync(Property property);
         void Delete(Property property);
         Task<bool> SaveAllAsync();
         Task<Property> GetSingleAsync(int propertyId);
         Task<IEnumerable<Property>> GetAllAsync();
         Task<IEnumerable<Property>> GetForDistrict(int districtId);
    }
}