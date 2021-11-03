//===================================================
// Date         : 
// Author       : 
// Description  : User implementation
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.DAL.Contexts;
using API.DAL.Interfaces;
using API.Helpers.Pagination;
using API.Helpers.Params;
using API.Models;
using Microsoft.EntityFrameworkCore;

public class UserRepo : IUserRepo
{
    private readonly AppDbContext _context;

    public UserRepo(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User> GetById(int id)
    {
        return await _context.User.FindAsync(id);
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _context.User.ToListAsync();
    }


    public async Task<PageList<User>> GetPage(UserParams parameter)
    {
        var users = _context.User.AsQueryable();

        var columnsMap = new Dictionary<string, Expression<Func<User, object>>>()
        {
            ["username"] = x => x.Username,
        };

        users = users.ApplyOrdering(parameter, columnsMap);
        return await PageList<User>
            .CreateAsync(users, parameter.PageNumber, parameter.PageSize);
    }

    public void Add(User user, string password)
    {
        byte[] passwordHash, passwordSalt;
        CreatePasswordHash(password, out passwordHash, out passwordSalt);
        user.PasswordHash = passwordHash;
        user.PasswordSalt = passwordSalt;

        _context.User.Add(user);
        _context.SaveChanges();
    }

    public void Update(User user, string password)
    {
        if (!String.IsNullOrEmpty(password))
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);
            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;
        }

        _context.User.Attach(user);
        _context.Entry(user).State = EntityState.Modified;
        _context.SaveChanges();
    }

    public void Remove(User user)
    {
        _context.Remove(user);
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
}