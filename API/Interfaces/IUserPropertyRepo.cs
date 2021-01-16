using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserPropertyRepo
    {
         Task AddAsync(UserProperty userProperty);
         void Delete(UserProperty userProperty);
         Task<bool> SaveAllAsync();
         Task<UserProperty> GetSingleAsync(int userId, int propertyId);
         Task<IEnumerable<UserProperty>> GetAllAsync();
         Task<IEnumerable<Property>> GetForUserAsync(int userId);
    }
}