using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IUserRepo
    {
         Task AddAsync(User user);
         void Delete(User user);
         Task<bool> SaveAllAsync();
         Task<User> GetSingleAsync(int userId);
         Task<User> GetSingleAsync(string userName);
         Task<IEnumerable<User>> GetAllAsync();
         Task<bool> IsUsernameTaken(string userName);
    }
}