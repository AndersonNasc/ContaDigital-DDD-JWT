using Application.Application;
using Application.Interface;
using Domain.Interfaces;
using Domain.Interfaces.Generics;
using Domain.Interfaces.InterfacesServices;
using Domain.Services;
using Infrastructure.Configuration;
using Infrastructure.Repository;
using Infrastructure.Repository.Generics;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using WebAPI.Token;

namespace WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<Entity.Entity.ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
                .AddEntityFrameworkStores<Context>();

            // INTERFACE E REPOSITORIO
            services.AddSingleton(typeof(IGenerics<>), typeof(RepositoryGenerecs<>));
            services.AddSingleton<IClient, RepositoryClient>();
            services.AddSingleton<IAccount, RepositoryAccount>();
            services.AddSingleton<IUser, RepositoryUser>();

            // SERVIÇO DOMINIO
            services.AddSingleton<IServiceClient, ServiceClient>();
            services.AddSingleton<IServiceAccount, ServiceAccount>();

            // INTERFACE APLICAÇÃO
            services.AddSingleton<IApplicationClient, ApplicationClient>();
            services.AddSingleton<IApplicationAccount, ApplicationAccount>();
            services.AddSingleton<IApplicationUser, ApplicationUser>();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
           .AddJwtBearer(option =>
           {
               option.TokenValidationParameters = new TokenValidationParameters
               {
                   ValidateIssuer = false,
                   ValidateAudience = false,
                   ValidateLifetime = true,
                   ValidateIssuerSigningKey = true,

                   ValidIssuer = "ContaDigital.Securiry.Bearer",
                   ValidAudience = "ContaDigital.Securiry.Bearer",
                   IssuerSigningKey = JwtSecurityKey.Create("Secret_Key")
               };

               option.Events = new JwtBearerEvents
               {
                   OnAuthenticationFailed = context =>
                   {
                       Console.WriteLine("OnAuthenticationFailed: " + context.Exception.Message);
                       return Task.CompletedTask;
                   },
                   OnTokenValidated = context =>
                   {
                       Console.WriteLine("OnTokenValidated: " + context.SecurityToken);
                       return Task.CompletedTask;
                   }
               };
           });



            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "WebAPI", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebAPI v1"));
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
