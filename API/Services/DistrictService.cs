using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class DistrictService : IDistrictService
    {
        private readonly IMapper _mapper;
        private readonly IDistrictRepo _repo;

        public DistrictService(IMapper mapper, IDistrictRepo repo)
        {
            _mapper =  mapper;
            _repo = repo;
        }
        public async Task<District> AddAsync(DistrictToAdd districtToAdd)
        {
            var dist = _mapper.Map<District>(districtToAdd);

            await _repo.AddAsync(dist);

            if(await _repo.SaveAllAsync()) return dist;

            throw new Exception("Podczas dodawania wystąpił błąd.");
        }

        public async Task<IAsyncResult> DeleteAsync(int districtId)
        {
            var dist = await _repo.GetSingleAsync(districtId);

            if (dist != null)
            {
                 _repo.Delete(dist);

                 if (await _repo.SaveAllAsync()) return Task.CompletedTask;

                 throw new Exception("Podczas usuwania wystąpił błąd.");
            }

            throw new Exception("Nie ma takiej dzielnicy.");      
        }

        public async Task<IEnumerable<District>> GetAllAsync()
        {
            return await _repo.GetAllAsync();
        }

        public async Task<District> GetAsync(int districtId)
        {
            return await _repo.GetSingleAsync(districtId);
        }
    }
}