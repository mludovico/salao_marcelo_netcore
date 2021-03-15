using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Salao_Marcelo.Data;
using Salao_Marcelo.Data.Interfaces;
using Salao_Marcelo.Data.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Salao_Marcelo
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
            services.AddControllers();

            // Dependency Injection
            services.AddScoped<IAppointmentRepository, AppointmentRepository>();
            services.AddScoped<ICashFlowRepository, CashFlowRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProfessionalRepository, ProfessionalRepository>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
            services.AddDbContext<Context>(options => 
                options.UseSqlServer(Configuration.GetConnectionString("sqlserver"))
            );

            // Add swagger
            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Salão de Beleza Marcelo",
                    Description = "Api para backend de um sistema de controle de um salão de beleza",
                    TermsOfService = new Uri("https://github.com/mludovico/salao_marcelo_netcore"),
                    Contact = new OpenApiContact
                    {
                        Name = "Marcelo Ludovico",
                        Email = "maludovico@gmail.com",
                        Url = new Uri("https://github.com/mludovico")
                    }
                });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                opt.IncludeXmlComments(xmlPath);
            });

            // Add Authentication
            var key = Encoding.ASCII.GetBytes(AuthConfiguration.Key);
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearer => {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Use swagger
            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint("api/v1/swagger.json", "Salão Marcelo");
            });

            app.UseHttpsRedirection();

            app.UseRouting();

            // Use Auth
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
