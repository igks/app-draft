//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : User controller
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Collections.Generic;
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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUserRepo _userRepo;

        public UserController(IMapper mapper, IUserRepo userRepo)
        {
            _mapper = mapper;
            _userRepo = userRepo;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            var result = _mapper.Map<User, UserOut>(user);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userRepo.GetAll();
            var result = _mapper.Map<IEnumerable<UserOut>>(users);
            return Ok(result);
        }

        [HttpGet("page")]
        public async Task<IActionResult> GetPage([FromQuery] UserParams parameter)
        {
            var users = await _userRepo.GetPage(parameter);
            var result = _mapper.Map<IEnumerable<UserOut>>(users);
            Response.AddPagination(users.CurrentPage, users.PageSize, users.TotalItems, users.TotalPages);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserIn dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<UserIn, User>(dto);
            var password = dto.Password;
            _userRepo.Add(user, password);

            user = await _userRepo.GetById(user.Id);
            var result = _mapper.Map<User, UserOut>(user);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] UserIn dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (id != dto.Id.Value)
                return BadRequest("Id is required!");

            var user = await _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            user = _mapper.Map(dto, user);
            _userRepo.Update(user, dto.Password);

            user = await _userRepo.GetById(user.Id);
            var result = _mapper.Map<User, UserOut>(user);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _userRepo.GetById(id);
            if (user == null)
                return NotFound();

            _userRepo.Delete(user);
            return Ok(id);
        }
    }
}