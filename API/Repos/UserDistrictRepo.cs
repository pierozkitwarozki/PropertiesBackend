using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.Others;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    
    public class UserDistrictRepo : IUserDistrictRepo
    {
        private readonly DatabaseContext _context;

        public UserDistrictRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(UserDistrict userProperty)
        {
            await _context.AddAsync(userProperty);
        }

        public void Delete(UserDistrict userProperty)
        {
            _context.Remove(userProperty);
        }

        public async Task<IEnumerable<UserDistrict>> GetAllAsync()
        {
            return await _context.UserDistricts
                .Include(x => x.District).ThenInclude(x => x.Properties).ToListAsync();
        }

        public async Task<IEnumerable<District>> GetForUserAsync(int userId)
        {
            return await _context
                .UserDistricts.Where(x => x.UserId == userId)
                .Include(p => p.District).ThenInclude(x => x.Properties)
                .Select(x => x.District).ToListAsync();
        }

        public async Task<UserDistrict> GetSingleAsync(int userId, int propertyId)
        {
            return await _context.UserDistricts.FindAsync(propertyId, userId);
        }

        public async Task<bool> SaveAllAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}