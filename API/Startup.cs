using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.DAL.Contexts;
using API.Helpers.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using CVB.CSI.Models;
using Microsoft.AspNetCore.Authorization;

namespace API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string CustomCORS = "_customCORS";

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // services.AddCors();
            services.AddCors(options =>
                {
                    options.AddPolicy(name: CustomCORS,
                                    builder =>
                                    {
                                        builder.WithOrigins("http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod()
                                            .AllowCredentials();
                                    });
                });

            services.AddControllers();

            // DB context
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("AppDbConnection")));

            // Add application setting/configuration
            services.Configure<Security>(options => Configuration.GetSection("Security").Bind(options));
            services.Configure<ServerConfig>(options => Configuration.GetSection("ServerConfig").Bind(options));

            // Auto mapper
            services.AddAutoMapper(typeof(Startup));

            // Map repository
            InterfaceMapper.Map(services);

            // JWT security
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                    .GetBytes(Configuration.GetSection("Security:JWTSecretToken").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });

            // API documentation
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Project Skeleton V1");
                    c.RoutePrefix = "doc";
                    c.DefaultModelsExpandDepth(-1);
                });
            }

            app.UseCors(CustomCORS);

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                if (!Configuration.GetValue<bool>("SystemConfig:EnableAuthorization"))
                    endpoints.MapControllers().WithMetadata(new AllowAnonymousAttribute());
                else
                    endpoints.MapControllers();
            });
        }
    }
}
