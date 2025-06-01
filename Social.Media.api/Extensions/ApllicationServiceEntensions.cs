using System;
using Microsoft.EntityFrameworkCore;
using Social.Media.api.Data;
using Social.Media.api.Helpers;
using Social.Media.api.Interfaces;
using Social.Media.api.Services;

namespace Social.Media.api.Extensions;

public static class ApllicationServiceEntensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
    {
        services.AddControllers();
        services.AddDbContext<DataContext>(opt =>
        {
            opt.UseSqlite(config.GetConnectionString("DefaultConnection"));
        });
        services.AddCors();
        services.AddScoped<ITokenService, TokenService>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}
