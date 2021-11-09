//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Authentication controller
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using API.DAL.Interfaces;
using API.DTO;
using API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IAuthRepo _authRepo;


        private readonly ServerConfig _serverConfig;

        public AuthController(IMapper mapper, IAuthRepo authRepo, IOptions<ServerConfig> serverConfig)
        {
            _mapper = mapper;
            _authRepo = authRepo;
            _serverConfig = serverConfig.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _authRepo.Login(dto.Username, dto.Password);
            if (result == null)
                return BadRequest("Credential invalid or account is unregistered!");

            return Ok(result);
        }

        [HttpGet("login-sso")]
        public IActionResult LoginSSO()
        {
            var domainArray = User.Identity.Name.Split("\\");
            var username = domainArray[domainArray.Length - 1];
            return Ok(new
            {
                isAuthenticated = User.Identity.IsAuthenticated
            });
        }

        [HttpPost("login-ad")]
        public IActionResult LoginAD([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var de = new DirectoryEntry($"LDAP://{_serverConfig.ADDomain}", dto.Username, dto.Password);
                var ds = new DirectorySearcher(de);
                SearchResult userAD = ds.FindOne();

                if (userAD == null)
                {
                    return BadRequest("Given credential is invalid!");
                }

            }
            catch
            {
                return BadRequest("Given credential is invalid!");
            }

            return Ok();
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserIn dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var user = _mapper.Map<UserIn, User>(dto);
            var password = dto.Password;
            _authRepo.Register(user, password);
            return Ok("Register success");
        }
    }
}