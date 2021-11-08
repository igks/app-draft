//===================================================
// Date         : 
// Author       : 
// Description  : 
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using API.DAL.Contexts;
using API.DAL.Interfaces;
using API.Helpers.Pagination;
using API.Helpers.Params;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class MasterRepo : IMasterRepo
    {
        private readonly AppDbContext _context;

        public MasterRepo(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Master> GetById(long id)
        {
            return await _context.Master
                .Include(x => x.Details)
                .Include(x => x.Commons).OrderBy(x => x.Id)
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Master>> GetAll()
        {
            return await _context.Master
                .Include(x => x.Details)
                .Include(x => x.Commons).OrderBy(x => x.Id)
                .ToListAsync();
        }

        public async Task<PageList<Master>> GetPage(MasterParams parameter)
        {
            var masters = _context.Master
                .Include(x => x.Details)
                .Include(x => x.Commons).OrderBy(x => x.Id)
                .AsQueryable();

            var columnsMap = new Dictionary<string, Expression<Func<Master, object>>>()
            {
                ["masterproperty1"] = x => x.MasterProperty1,
                ["masterproperty2"] = x => x.MasterProperty2,
            };

            masters = masters.ApplyOrdering(parameter, columnsMap);
            return await PageList<Master>
                .CreateAsync(masters, parameter.PageNumber, parameter.PageSize);
        }

        public void Add(Master master)
        {
            _context.Master.Add(master);
            _context.SaveChanges();
        }

        public void Update(Master master)
        {
            _context.Master.Attach(master);
            _context.Entry(master).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(Master master)
        {
            _context.Remove(master);
            _context.SaveChanges();
        }
    }
}