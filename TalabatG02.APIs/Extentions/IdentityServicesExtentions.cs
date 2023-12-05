﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using TalabatG02.Core.Entities.Identity;
using TalabatG02.Core.Services;
using TalabatG02.Repository.Identity;
using TalabatG02.Service;

namespace TalabatG02.APIs.Extentions
{
    public static class IdentityServicesExtentions
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddIdentity<AppUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = true;
            }).AddEntityFrameworkStores<AppIdentityDbContext>();

            services.AddScoped<ITokenService, TokenService>();
            services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;    

                })
                    .AddJwtBearer(options =>
                    {
                        options.TokenValidationParameters = new TokenValidationParameters()
                        {
                            ValidateIssuer = true,
                            ValidIssuer = configuration["JWT:ValidIssuer"],
                            ValidateAudience = true,
                            ValidAudience = configuration["JWT:ValidAudience"],
                            ValidateLifetime = true,
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:key"]))
                        };
                    });

            return services;
        }
    }
}
