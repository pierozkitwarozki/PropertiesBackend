using System;
using System.Threading.Tasks;
using API.Dtos;

namespace API.Interfaces
{
    public interface IUserService
    {
         Task<IAsyncResult> EditAsync(string userId, UserToEdit userToEdit);
    }
}