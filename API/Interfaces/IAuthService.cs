using System.Threading.Tasks;
using API.Dtos;

namespace API.Interfaces
{
    public interface IAuthService
    {
         Task<UserDetail> RegisterAsync(UserToRegister userToRegister);
         Task<TokenToReturn> LoginAsync(UserToLogin userToLogin);
    }
}