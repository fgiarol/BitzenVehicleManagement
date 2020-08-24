using BitzenVehicleManagementAPI.Data;
using BitzenVehicleManagementAPI.Data.Repositories;
using BitzenVehicleManagementAPI.Extensions;
using BitzenVehicleManagementAPI.Models;
using BitzenVehicleManagementAPI.Models.Repositories;
using BitzenVehicleManagementAPI.Services;
using BitzenVehicleManagementAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

namespace BitzenVehicleManagementAPI
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
            services.AddDbContext<BitzenApplicationContext>(options =>
                    options.UseMySql(Configuration.GetConnectionString("default"), builder =>
                        builder.MigrationsAssembly("BitzenVehicleManagementAPI")));

            services.AddIdentity<User, IdentityRole<long>>()
                .AddRoles<IdentityRole<long>>()
                .AddEntityFrameworkStores<BitzenApplicationContext>()
                .AddDefaultTokenProviders();

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Bitzen",
                        Version = "v1",
                        Description = "BitzenVehicleManagementAPI",
                        Contact = new OpenApiContact
                        {
                            Name = "Fernando Giarola",
                            Url = new Uri("https://github.com/Fernandogr10")
                        }
                    });
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["jwt:key"])),
                    ClockSkew = TimeSpan.Zero
                };
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser, AspNetUser>();

            services.AddScoped<IVehicleService, VehicleService>();
            services.AddScoped<IFuelingService, FuelingService>();

            services.AddScoped<IVehicleRepository, VehicleRepository>();
            services.AddScoped<VehicleService>();

            services.AddScoped<IFuelingRepository, FuelingRepository>();
            services.AddScoped<FuelingService>();

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Bitzen V1");
            });
        }
    }
}
