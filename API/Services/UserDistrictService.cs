using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class UserDistrictService : IUserDistrictService
    {
        private readonly IMapper _mapper;
        private readonly IUserDistrictRepo _repo;

        public UserDistrictService(IMapper mapper, IUserDistrictRepo repo)
        {
            _mapper =  mapper;
            _repo = repo;
        }
        public async Task<IAsyncResult> AddAsync(UserDistrictToAdd userProperty)
        {
            var dist = _mapper.Map<UserDistrict>(userProperty);

            await _repo.AddAsync(dist);

            if(await _repo.SaveAllAsync()) return Task.CompletedTask;

            throw new Exception("Podczas dodawania wystąpił błąd.");
        }

        public async Task<IAsyncResult> DeleteAsync(int userId, int propertyId)
        {
            var dist = await _repo.GetSingleAsync(userId, propertyId);

            if (dist != null)
            {
                 _repo.Delete(dist);

                 if (await _repo.SaveAllAsync()) return Task.CompletedTask;

                 throw new Exception("Podczas usuwania wystąpił błąd.");
            }

            throw new Exception("Nie ma takiej pary.");   
        }

        public async Task<IEnumerable<UserDistrict>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<District>> GetForUserAsync(int userId)
        {
            return _mapper.Map<IEnumerable<District>>(await _repo.GetForUserAsync(userId));
        }

        public async Task<UserDistrict> GetSingleAsync(int userId, int propertyId)
        {
            return await _repo.GetSingleAsync(userId, propertyId);
        }
    }
}