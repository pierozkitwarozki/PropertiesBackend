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
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace API.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepo _repo;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;

        public AuthService(IUserRepo repo, IConfiguration config, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
            _config = config;
        }

        public IMapper Mapper => _mapper;

        public async Task<TokenToReturn> LoginAsync(UserToLogin userToLogin)
        {
            var user = await _repo.GetSingleAsync(userToLogin.UserName);

            if(user != null)
            {
                if(PasswordManager.VerifyPasswordHash(userToLogin.Password, user.PasswordHash, user.PasswordSalt))
                {
                    var claims = new[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                        new Claim(ClaimTypes.Name, userToLogin.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(_config.GetSection("AppSettings:Token").Value));

                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Expires = DateTime.Now.AddDays(1),
                        SigningCredentials = creds
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();

                    var token = tokenHandler.CreateToken(tokenDescriptor);

                    var userDetail = _mapper.Map<UserDetail>(user);

                    return new TokenToReturn { Token = tokenHandler.WriteToken(token), User = userDetail };
                }

                throw new Exception("Zła nazwa użytkownika lub hasło!");
            }

            throw new Exception("Zła nazwa użytkownika lub hasło!");
 
        }

        public async Task<UserDetail> RegisterAsync(UserToRegister userToRegister)
        {
            if(userToRegister.Password != userToRegister.ConfirmPassword) 
                throw new Exception("Hasła nie są takie same.");

            userToRegister.UserName = userToRegister.UserName.ToLower();

            if (await _repo.IsUsernameTaken(userToRegister.UserName))
                throw new Exception("Nazwa użytkownika jest już zajęta");

            var user = _mapper.Map<User>(userToRegister);

            byte[] passwordHash, passwordSalt;
            PasswordManager.CreatePasswordHash(userToRegister.Password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await _repo.AddAsync(user);

            if(await _repo.SaveAllAsync())  
                return _mapper.Map<UserDetail>(user);

            throw new Exception("Podczas dodawania użytkownika wystąpił błąd.");
        }
    }
}