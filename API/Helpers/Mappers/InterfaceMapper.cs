//===================================================
// Date         : 03 Nov 2021
// Author       : I Gusti Kade Sugiantara
// Description  : Interface mapper, map repository to the interface
//===================================================
// Revision History:
// Name             Date            Description
//
//===================================================
using API.DAL.Interfaces;
using API.DAL.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace API.Helpers.Mappers
{
    public static class InterfaceMapper
    {
        public static void Map(IServiceCollection services)
        {
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddScoped<IMasterRepo, MasterRepo>();
            services.AddScoped<ICommonRepo, CommonRepo>();
        }
    }
}