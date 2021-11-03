//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication implementation
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Threading.Tasks;
using API.DAL.Contexts;
using API.DAL.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class AuthRepo : IAuthRepo
    {
        private readonly AppDbContext _context;

        public AuthRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<User> Login(string username, string password)
        {
            var user = await _context.User.FirstOrDefaultAsync(u => u.Username == username);
            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
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
    }
}