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
using AutoMapper;
using CVB.CSI.Models;
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

        public readonly Security _security;

        private readonly ServerConfig _serverConfig;

        public AuthController(IMapper mapper, IAuthRepo authRepo, IOptions<Security> security, IOptions<ServerConfig> serverConfig)
        {
            _mapper = mapper;
            _authRepo = authRepo;
            _security = security.Value;
            _serverConfig = serverConfig.Value;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var userLogin = await _authRepo.Login(dto.Username, dto.Password);
            if (userLogin == null)
                return BadRequest("Credential invalid or account is unregistered!");

            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, userLogin.Username));
            claims.Add(new Claim("Id", userLogin.Id.ToString()));

            var key = new SymmetricSecurityKey(Encoding.UTF8
                .GetBytes(_security.JWTSecretToken));

            var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credential
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var user = _mapper.Map<UserOutput>(userLogin);

            return Ok(new
            {
                token = tokenHandler.WriteToken(token),
                user
            });
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
    }
}