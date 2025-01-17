using EntityFramework.Exceptions.PostgreSQL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using API_GruasUCAB.Users.Infrastructure.Database;
using API_GruasUCAB.Users.Infrastructure.Settings;
using API_GruasUCAB.Users.Core.Database;
//using RabbitMQ.Client;
//using API_GruasUCAB.Users.RabbitMQ;

namespace API_GruasUCAB.Users
{
    public class Startup
    {
        private static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();

            var _appSettings = new AppSettings();
            var appSettingsSection = builder.Configuration.GetSection("AppSettings");
            _appSettings = appSettingsSection.Get<AppSettings>();
            builder.Services.Configure<AppSettings>(appSettingsSection);

            builder.Services.AddTransient<IUserDbContext, UserDbContext>();

            var dbConnectionString = builder.Configuration.GetValue<string>("DBConnectionString");

            builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));


            builder.Services.AddDbContext<UserDbContext>(options =>
            options.UseNpgsql(dbConnectionString)
            .UseExceptionProcessor());


            var app = builder.Build();
            // Configuración de middlewares
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
        }
    }
}
