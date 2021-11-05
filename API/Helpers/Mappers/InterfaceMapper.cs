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
using API.Helpers.Mailing;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API.Helpers.Mappers
{
    public static class InterfaceMapper
    {
        public static void Map(IServiceCollection services)
        {
            services.AddSingleton<EmailSenderService>();
            services.AddSingleton<IHostedService>(serviceProvider => serviceProvider.GetService<EmailSenderService>());
            services.AddSingleton<IEmailSender>(serviceProvider => serviceProvider.GetService<EmailSenderService>());

            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IAuthRepo, AuthRepo>();
            services.AddScoped<IEmailRepo, EmailRepo>();
            services.AddScoped<IMasterRepo, MasterRepo>();
            services.AddScoped<ICommonRepo, CommonRepo>();
        }
    }
}