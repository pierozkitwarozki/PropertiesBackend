using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using API.Others;
using Microsoft.EntityFrameworkCore;

namespace API.Repos
{
    public class PropertyRepo : IPropertyRepo
    {
        private readonly DatabaseContext _context;

        public PropertyRepo(DatabaseContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Property property)
        {
            await _context.AddAsync(property);
        }

        public void Delete(Property property)
        {
            _context.Remove(property);
        }

        public async Task<IEnumerable<Property>> GetAllAsync()
        {
            return await _context.Property.ToListAsync();
        }

        public async Task<IEnumerable<Property>> GetForDistrict(int districtId)
        {
            return await _context.Property.Where(x => x.DistrictId == districtId)
                .Include(x => x.District).ToListAsync();
        }

        public async Task<Property> GetSingleAsync(int propertyId)
        {
            return await _context.Property.FindAsync(propertyId);
        }

        public async Task<bool> SaveAllAsync()
        {
           return await _context.SaveChangesAsync() > 0;
        }
    }
}