using API.DAL.Contexts;
using API.Helpers.Mappers;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using FluentValidation.AspNetCore;
using API.Validations;
using API.Models;

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

        public void ConfigureServices(IServiceCollection services)
        {
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

            services.AddControllers()
            .AddNewtonsoftJson(option => option.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore)
            .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<MasterValidator>());

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Configuration.GetConnectionString("AppDbConnection")));

            services.Configure<Security>(options => Configuration.GetSection("Security").Bind(options));
            services.Configure<ServerConfig>(options => Configuration.GetSection("ServerConfig").Bind(options));
            services.Configure<SystemConfig>(options => Configuration.GetSection("SystemConfig").Bind(options));

            services.AddAutoMapper(typeof(Startup));

            InterfaceMapper.Map(services);

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

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });
            });
        }

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

            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                if (!Configuration.GetValue<bool>("SystemConfig:EnableAuthorization"))
                    endpoints.MapControllers().WithMetadata(new AllowAnonymousAttribute());
                else
                    endpoints.MapControllers();

                endpoints.MapControllerRoute("SPA", "*{url}", defaults: new { controllers = "SPA", action = "Index" });
            });
        }
    }
}
