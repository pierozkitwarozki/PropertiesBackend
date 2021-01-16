using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.Others;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class UserPropertyRepo : IUserPropertyRepo
    {
        private readonly DatabaseContext _context;

        public UserPropertyRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(UserProperty userProperty)
        {
            await _context.AddAsync(userProperty);
        }

        public void Delete(UserProperty userProperty)
        {
            _context.Remove(userProperty);
        }

        public async Task<IEnumerable<UserProperty>> GetAllAsync()
        {
            return await _context.UserProperty.ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetForUser(int userId)
        {
            return await _context
                .UserProperty.Where(x => x.UserId == userId)
                .Include(p => p.Property).ThenInclude(x => x.District)
                .Select(x => x.Property).ToListAsync();
        }

        public async Task<UserProperty> GetSingleAsync(int userId, int propertyId)
        {
            return await _context.UserProperty.FindAsync(new { propertyId, userId });
        }

        public async Task<bool> SaveAllAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}