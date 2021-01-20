using System;
using System.Threading.Tasks;
using API.Dtos;
using API.Interfaces;
using API.Entities;
using Microsoft.AspNetCore.Identity;

namespace API.Services
{
    public class UserService : IUserService
    {
        public UserManager<AppUser> _manager { get; }
        public UserService(UserManager<AppUser> manager)
        {
            _manager = manager;
        }
        public async Task<IAsyncResult> EditAsync(string userId, UserToEdit userToEdit)
        {
            var userFromRepo = await _manager.FindByIdAsync(userId.ToString());

            if(userFromRepo == null) throw new Exception("Nie ma takiego użytkownika");

            if(!string.IsNullOrEmpty(userToEdit.FirstName)) userFromRepo.FirstName = userToEdit.FirstName;
            if(!string.IsNullOrEmpty(userToEdit.LastName)) userFromRepo.LastName = userToEdit.LastName;

            var result = _manager.UpdateAsync(userFromRepo);

            if(result.IsCompletedSuccessfully) return Task.CompletedTask;

            throw new Exception("Wystąpił błąd.");
        }
    }
}