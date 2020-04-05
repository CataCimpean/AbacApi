using Abac.Web.Api.Core.DTO;
using Abac.Web.Api.Core.Helpers;
using Abac.Web.Api.Infrastructure.Entities;
using Abac.Web.Api.Infrastructure.Repository;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Abac.Web.Api.Core.BLLService
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private readonly IAbacRepository<User> _userRepository;
        private readonly IMapper _mapper;
        public UserService(IAbacRepository<User> userRepository, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        public UserDTO Authenticate(string username, string password)
        {
            var encodedPassword = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            var user = _userRepository
                            .GetAll()
                            .Include(ur => ur.UserRole)
                            .ThenInclude(r =>r.Role)
                            .Where(x => x.Username == username
                                     && x.Password == encodedPassword)
                            .FirstOrDefault();

            // return null if user not found
            if (user == null)
                return null;

            var userDTO = _mapper.Map<UserDTO>(user);

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

            var claims = new List<Claim>();

            //Add Role claims
            if (userDTO.Roles != null && userDTO.Roles.Length > 0)
            {
                foreach (string item in userDTO.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, item));
                }
            }
            //Add User claim
            claims.Add(new Claim(ClaimTypes.Name, user.Id.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims.ToArray()),
                Expires = DateTime.Now.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            user.Token = tokenHandler.WriteToken(token);
            user.TokenExpirationDate = tokenDescriptor.Expires;

            //update jwt token to Db
            _userRepository.Update(user, user.Id);

            //return result ->userDTO(without user password)
            userDTO = _mapper.Map<UserDTO>(user);
            return userDTO;
        }

        public IEnumerable<UserDTO> GetAll()
        {
            var userDb = _userRepository.GetAll().ToList();
            var result = _mapper.Map<List<UserDTO>>(userDb);
            return result;
        }
    }
}
