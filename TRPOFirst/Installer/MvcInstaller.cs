using Microsoft.AspNetCore.Mvc;

namespace TRPOFirst.Installer;

public class MvcInstaller
{
    public void InstalServices(IServiceCollection services, IConfiguration configuration)
    {
        services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

        services.AddSwaggerGen(x =>
        {
            //x.SwaggerDoc("v1", new Info { Title = "Hospital API", Version = "v1" });
        });
    }
}