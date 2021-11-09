//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication implementation
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.DAL.Contexts;
using API.DAL.Interfaces;
using API.DTO;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.DAL.Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly Security _security;

        public AuthRepo(AppDbContext context, IMapper mapper, IOptions<Security> security)
        {
            _context = context;
            _mapper = mapper;
            _security = security.Value;

        }

        public async Task<AuthenticatedUser> Login(string username, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            var result = TokenHandler(user);
            return result;
        }

        public void Register(User user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            _context.User.Add(user);
            _context.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
                return true;
            }
        }

        private AuthenticatedUser TokenHandler(User user)
        {
            var userId = user.Id.ToString();
            var userName = user.Username;

            var claims = new List<Claim>();
            claims.Add(new Claim("Id", userId));
            claims.Add(new Claim("Username", userName));

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_security.JWTSecretToken));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var timeExpire = DateTime.Now.AddDays(1);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = timeExpire,
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var userData = _mapper.Map<UserOut>(user);

            return new AuthenticatedUser
            {
                Token = tokenHandler.WriteToken(token),
                TokenExpired = timeExpire,
                User = userData
            };
        }
    }
}