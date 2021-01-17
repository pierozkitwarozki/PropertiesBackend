using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.Others;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class DistrictRepo : IDistrictRepo
    {
        private readonly DatabaseContext _context;

        public DistrictRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(District district)
        {
            await _context.AddAsync(district);
        }

        public void Delete(District district)
        {
            _context.Remove(district);
        }

        public async Task<bool> SaveAllAsync()
        {
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<District> GetSingleAsync(int districtId)
        {
            return await _context.Districts.FindAsync(districtId);
        }

        public async Task<IEnumerable<District>> GetAllAsync()
        {
            return await _context.Districts.ToListAsync();
        }

    }
}