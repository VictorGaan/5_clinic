using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using TRPOFirst.Data;

namespace TRPOFirst.Installer;

/// <summary>
/// Методы расширения с более удобный внедрением реализации контекста
/// </summary>
public static class DbInstaller
{
    public static void AddDbContext(this IServiceCollection services, string? configuration)
    {
         // services.AddDbContext<DataContext>(options =>
         //     options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));
         // services.AddDefaultIdentity<IdentityUser>()
         //     .AddEntityFrameworkStores<DataContext>();
         // services.AddSingleton<IDoctorService, DoctorService>();
    }
}