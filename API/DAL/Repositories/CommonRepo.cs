//===================================================
// Date         : 
// Author       : 
// Description  : 
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DAL.Contexts;
using API.DAL.Interfaces;
using API.DTO;
using API.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace API.DAL.Repositories
{
    public class CommonRepo : ICommonRepo
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;

        public CommonRepo(AppDbContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<Common> GetById(long id)
        {
            return await _context.Common.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IList<long>> GetIdList(long masterId)
        {
            return await _context.Common.Where(x => x.MasterId == masterId).Select(x => x.Id).ToListAsync();
        }

        public void Add(CommonDto dto)
        {
            foreach (var item in dto.CommonsIn.ToList())
            {
                var common = new Common
                {
                    MasterId = dto.MasterId,
                    CommonProperty1 = item.CommonProperty1,
                    CommonProperty2 = item.CommonProperty2
                };
                _context.Common.Add(common);
                _context.SaveChanges();
            }
        }

        public async Task Update(CommonDto dto)
        {
            var currentRecords = await GetIdList(dto.MasterId);
            var newRecords = new List<long>();

            foreach (var item in dto.CommonsIn)
            {
                if (item.Id.HasValue)
                {
                    var common = await GetById(item.Id.Value);
                    if (common != null)
                    {
                        common = _mapper.Map(item, common);
                        _context.Common.Attach(common);
                        _context.Entry(common).State = EntityState.Modified;
                        newRecords.Add(item.Id.Value);
                    }
                }
                else
                {
                    var common = new Common
                    {
                        MasterId = dto.MasterId,
                        CommonProperty1 = item.CommonProperty1,
                        CommonProperty2 = item.CommonProperty2
                    };
                    _context.Common.Add(common);
                }
            }

            foreach (var id in currentRecords)
            {
                if (!newRecords.Contains(id))
                {
                    var common = await GetById(id);
                    if (common != null)
                        _context.Remove(common);

                }
            }
            _context.SaveChanges();
        }

        public async Task Delete(CommonDto dto)
        {
            var currentRecords = await GetIdList(dto.MasterId);
            foreach (var id in currentRecords)
            {
                var common = await GetById(id);
                if (common != null)
                {
                    _context.Remove(common);
                }
            }
            _context.SaveChanges();
        }
    }
}