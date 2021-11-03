//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Auto mapper class
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using API.DTO;
using API.Models;
using AutoMapper;

namespace API.Helpers.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserInput, User>();
            CreateMap<User, UserOutput>();
        }
    }
}