using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using AutoMapper;

namespace API.Services
{
    public class PropertyService : IPropertyService
    {
        private readonly IMapper _mapper;
        private readonly IPropertyRepo _repo;

        public PropertyService(IMapper mapper, IPropertyRepo repo)
        {
            _mapper =  mapper;
            _repo = repo;
        }
        public async Task<PropertyToReturn> AddAsync(PropertyToAdd propertyToAdd)
        {
            var dist = _mapper.Map<Property>(propertyToAdd);

            await _repo.AddAsync(dist);

            if(await _repo.SaveAllAsync()) return _mapper.Map<PropertyToReturn>(dist);

            throw new Exception("Podczas dodawania wystąpił błąd.");
        }

        public async Task<IAsyncResult> DeleteAsync(int propertyId)
        {
            var dist = await _repo.GetSingleAsync(propertyId);

            if (dist != null)
            {
                 _repo.Delete(dist);

                 if (await _repo.SaveAllAsync()) return Task.CompletedTask;

                 throw new Exception("Podczas usuwania wystąpił błąd.");
            }

            throw new Exception("Nie ma takiej nieruchomości.");      
        }

        public async Task<IEnumerable<PropertyToReturn>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PropertyToReturn>>(await _repo.GetAllAsync());
        }

        public async Task<PropertyToReturn> GetAsync(int propertyId)
        {
            return _mapper.Map<PropertyToReturn>(await _repo.GetSingleAsync(propertyId));
        }

        public async Task<IEnumerable<PropertyToReturn>> GetForDistrictAsync(int districtId)
        {
            return _mapper.Map<IEnumerable<PropertyToReturn>>(await _repo.GetForDistrict(districtId));
        }
    }
}