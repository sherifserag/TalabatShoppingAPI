using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;
using TalabatG02.APIs.Errors;
using TalabatG02.APIs.Extentions;
using TalabatG02.APIs.Helpers;
using TalabatG02.APIs.Middlewares;
using TalabatG02.Core.Entities;
using TalabatG02.Core.Entities.Identity;
using TalabatG02.Core.Repositories;
using TalabatG02.Repository;
using TalabatG02.Repository.Data;
using TalabatG02.Repository.Identity;

namespace TalabatG02.APIs
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            #region Configure Services Works With DI

            builder.Services.AddControllers();

            //----Database Services
            builder.Services.AddDbContext<StoreContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddSingleton<IConnectionMultiplexer>(options =>
            {
                var connection = builder.Configuration.GetConnectionString("Redis");
                return ConnectionMultiplexer.Connect(connection);
            });
            builder.Services.AddDbContext<AppIdentityDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("IdentityConnection"));
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("MyPolicy",options =>
                {
                    options.AllowAnyHeader().AllowAnyMethod().WithOrigins(builder.Configuration["FrontBaseUrl"]);
                });
            });


            //----------Extentions Servicess
            builder.Services.AddIdentityServices(builder.Configuration);
            builder.Services.AddApplicationServices();
            builder.Services.AddSwaggerServices();

            #endregion
         
            var app = builder.Build();


            #region Update-Database inside Main
            var scope = app.Services.CreateScope();//Services Scoped
            var services = scope.ServiceProvider;   //DI
            //LoggerFacotry
            var LoggerFactory = services.GetRequiredService<ILoggerFactory>();
            try
            {
                var dbContext = services.GetRequiredService<StoreContext>(); //Ask Clr to Create Object from Store Context Explicitly
                await dbContext.Database.MigrateAsync();//Update-database
                await StoreContextSeed.SeedAsync(dbContext);

                var IdentityDbContext = services.GetRequiredService<AppIdentityDbContext>();
                await IdentityDbContext.Database.MigrateAsync();

                var userManager = services.GetRequiredService<UserManager<AppUser>>();
                await AppIdentityDbContextSeed.SeedUsersAsync(userManager);

            }
            catch (Exception ex)
            {
                var logger = LoggerFactory.CreateLogger<Program>();
                logger.LogError(ex, "an error Occured during apply the Migration");
            }

            #endregion

            #region Cofigure request into Piplines
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwaggerMiddlewares();
            }
            app.UseMiddleware<ExceptionMiddleware>();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCors("MyPolicy");

            app.UseStatusCodePagesWithRedirects("/errors/{0}");

            app.UseAuthentication();
            app.UseAuthorization();


          

            app.MapControllers(); //Controller
            #endregion

            app.Run();
        }
    }
}