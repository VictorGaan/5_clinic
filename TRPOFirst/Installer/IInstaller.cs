using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
//using TRPOFirst.Data;

namespace TRPOFirst.Installer;

public interface IInstaller
{
    void InstallServeses(IServiceCollection serveces, IConfiguration configuration);
}