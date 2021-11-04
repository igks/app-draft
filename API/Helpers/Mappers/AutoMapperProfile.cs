//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Auto mapper class
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using System.Linq;
using API.DTO;
using API.Models;
using AutoMapper;

namespace API.Helpers.Mappers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<UserIn, User>();
            CreateMap<User, UserOut>();

            CreateMap<MasterIn, Master>()
                .ForMember(to => to.Details, option => option.MapFrom(src => src.Details))
                .ForMember(to => to.Commons, option => option.Ignore());
            CreateMap<Master, MasterOut>();

            CreateMap<DetailIn, Detail>();
            CreateMap<Detail, DetailOut>();

            CreateMap<CommonIn, Common>();
            CreateMap<Common, CommonOut>();
        }
    }
}