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
using API.DAL.Interfaces;
using API.DTO;
using API.Helpers.Pagination;
using API.Helpers.Params;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class MasterController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IMasterRepo _masterRepo;
        private readonly ICommonRepo _commonRepo;

        public MasterController(IMapper mapper, IMasterRepo masterRepo, ICommonRepo commonRepo)
        {
            _mapper = mapper;
            _masterRepo = masterRepo;
            _commonRepo = commonRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(long id)
        {
            var master = await _masterRepo.GetById(id);
            if (master == null)
                return NotFound();

            var result = _mapper.Map<Master, MasterOut>(master);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var masters = await _masterRepo.GetAll();
            var result = _mapper.Map<IEnumerable<MasterOut>>(masters);
            return Ok(result);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetPage([FromQuery] MasterParams parameter)
        {
            var masters = await _masterRepo.GetPage(parameter);
            var result = _mapper.Map<IEnumerable<MasterOut>>(masters);
            Response.AddPagination(masters.CurrentPage, masters.PageSize, masters.TotalItems, masters.TotalPages);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] MasterIn dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var master = _mapper.Map<MasterIn, Master>(dto);
            _masterRepo.Add(master);

            var commonDto = new CommonDto
            {
                MasterId = master.Id,
                CommonsIn = dto.Commons
            };
            _commonRepo.Add(commonDto);

            master = await _masterRepo.GetById(master.Id);
            var result = _mapper.Map<Master, MasterOut>(master);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] MasterIn dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.Id.Value)
                return BadRequest("Id is required!");

            var master = await _masterRepo.GetById(id);
            if (master == null)
                return NotFound();

            master = _mapper.Map(dto, master);
            _masterRepo.Update(master);

            var commonDto = new CommonDto
            {
                MasterId = master.Id,
                CommonsIn = dto.Commons
            };
            await _commonRepo.Update(commonDto);

            master = await _masterRepo.GetById(master.Id);
            var result = _mapper.Map<Master, MasterOut>(master);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            var master = await _masterRepo.GetById(id);
            if (master == null)
                return NotFound();

            _masterRepo.Remove(master);

            var commonDto = new CommonDto
            {
                MasterId = master.Id,
                CommonsIn = null
            };
            await _commonRepo.Delete(commonDto);

            return Ok(id);
        }
    }
}