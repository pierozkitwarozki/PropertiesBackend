using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class UserPropertyService : IUserPropertyService
    {
        private readonly IMapper _mapper;
        private readonly IUserPropertyRepo _repo;

        public UserPropertyService(IMapper mapper, IUserPropertyRepo repo)
        {
            _mapper =  mapper;
            _repo = repo;
        }
        public async Task<IAsyncResult> AddAsync(UserPropertyToAdd userProperty)
        {
            var dist = _mapper.Map<UserProperty>(userProperty);

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

        public async Task<IEnumerable<UserProperty>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<IEnumerable<PropertyToReturn>> GetForUserAsync(int userId)
        {
            return _mapper.Map<IEnumerable<PropertyToReturn>>(await _repo.GetForUserAsync(userId));
        }

        public async Task<UserProperty> GetSingleAsync(int userId, int propertyId)
        {
            return await _repo.GetSingleAsync(userId, propertyId);
        }
    }
}