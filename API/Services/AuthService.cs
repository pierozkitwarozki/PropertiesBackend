using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.Dtos;
using API.Entities;
using API.Interfaces;
using API.Others;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepo _userRepo;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;
        //private readonly IConfiguration _config;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> manager, SignInManager<AppUser> signInManager,
            ITokenService tokenService, IConfiguration config, IMapper mapper, IUserRepo userRepo)
        {
            _tokenService = tokenService;
            _mapper = mapper;
            _userManager = manager;
            _userRepo = userRepo;
            _signInManager = signInManager;
        }

        public IMapper Mapper => _mapper;

        public async Task<TokenToReturn> LoginAsync(UserToLogin userToLogin)
        {
            userToLogin.UserName = userToLogin.UserName.ToLower();

            var userFromRepo = await _userRepo.GetSingleAsync(userToLogin.UserName);

            if (userFromRepo == null)
                throw new Exception("Wrong credentials.");

            var result = await _signInManager
                .CheckPasswordSignInAsync(userFromRepo, userToLogin.Password, false);

            if (!result.Succeeded) throw new Exception("Error occurred");

            var userToReturn = _mapper.Map<UserDetail>(userFromRepo);

            var tokenToReturn = new TokenToReturn 
            {
                Token = await _tokenService.CreateTokenAsync(userFromRepo),
                User = userToReturn
            };

            return tokenToReturn;

        }

        public async Task<UserDetail> RegisterAsync(UserToRegister userToRegister)
        {
            if (userToRegister.Password != userToRegister.ConfirmPassword)
                throw new Exception("Hasła nie są takie same.");

            if(await _userManager.FindByNameAsync(userToRegister.UserName)!=null)
                throw new Exception("Username is already taken.");

            var userToCreate = _mapper.Map<AppUser>(userToRegister);

            var result = await _userManager.CreateAsync(userToCreate, userToRegister.Password);

            if(userToRegister.Role.ToLower() == "admin") 
            {
                await _userManager.AddToRoleAsync(userToCreate, "Admin");
            }
            else 
            {
                await _userManager.AddToRoleAsync(userToCreate, "User");
            }

            if(!result.Succeeded) throw new Exception(result.Errors.ToString());

            return _mapper.Map<UserDetail>(userToCreate);
        }
    }
}