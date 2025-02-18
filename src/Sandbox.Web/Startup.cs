namespace Sandbox.Web;

public class Startup(IWebHostEnvironment webHostingEnvironment, IConfiguration configuration)
{
    private readonly Foundation.Startup _foundationStartup = new(webHostingEnvironment, configuration);

    public void ConfigureServices(IServiceCollection services)
    {
        _foundationStartup.ConfigureServices(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        _foundationStartup.Configure(app, env);
    }
}