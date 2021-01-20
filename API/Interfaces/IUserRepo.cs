using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepo
    {
         Task AddAsync(AppUser user);
         void Delete(AppUser user);
         Task<bool> SaveAllAsync();
         Task<AppUser> GetSingleAsync(int userId);
         Task<AppUser> GetSingleAsync(string userName);
         Task<IEnumerable<AppUser>> GetAllAsync();
         Task<bool> IsUsernameTaken(string userName);
    }
}