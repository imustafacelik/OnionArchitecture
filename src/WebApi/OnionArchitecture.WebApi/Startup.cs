using OnionArchitecture.Application;
using OnionArchitecture.Persistence;

namespace OnionArchitecture.WebApi;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddApplicationRegistration();
        services.AddPersistanceServices();


        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        //add configuration/middleware here

    }

}
