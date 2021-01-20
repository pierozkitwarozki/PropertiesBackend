using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.Others;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly DatabaseContext _context;

        public UserRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AppUser user)
        {
            await _context.AddAsync(user);
        }

        public void Delete(AppUser user)
        {
            _context.Remove(user);
        }

        public async Task<IEnumerable<AppUser>> GetAllAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<AppUser> GetSingleAsync(int userId)
        {
            return await _context.Users.FindAsync(userId);
        }

        public async Task<AppUser> GetSingleAsync(string userName)
        {
            return await _context.Users.Include(x => x.UserRoles)
                .ThenInclude(x => x.Role).SingleAsync(x => x.UserName == userName);
        }

        public async Task<bool> IsUsernameTaken(string userName)
        {
            return await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName) != null;
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }
    }
}